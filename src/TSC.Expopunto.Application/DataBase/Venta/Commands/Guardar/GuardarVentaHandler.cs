using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.LineaCredito.Commands;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;
using TSC.Expopunto.Application.Interfaces.Repositories.Estado;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.DocumentoEstado;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Crear
{
    public class GuardarVentaHandler : IRequestHandler<GuardarVentaCommand, VentaDTO>
    {
        private readonly IVentaRepository _repository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDocumentoEstadoRepository _documentoEstadoRepository;
        private readonly ILineaCreditoQuery _lineaCreditoQuery;
        private readonly ILineaCreditoCommand _lineaCreditoCommand;

        public GuardarVentaHandler(
            IVentaRepository repository,
            IEstadoRepository estadoRepository,
            IDocumentoEstadoRepository documentoEstadoRepository,
            ILineaCreditoQuery lineaCreditoQuery,
            ILineaCreditoCommand lineaCreditoCommand
        )
        {
            _repository = repository;
            _estadoRepository = estadoRepository;
            _documentoEstadoRepository = documentoEstadoRepository;
            _lineaCreditoQuery = lineaCreditoQuery;
            _lineaCreditoCommand = lineaCreditoCommand;
        }

        public async Task<VentaDTO> Handle(GuardarVentaCommand request, CancellationToken cancellationToken)
        {
            VentaEntity venta = new VentaEntity();
            int idTipoProceso = 2; // 1:GUIA - 2:VENTAS
            VentaFormaPagoCommand formaPagoPlanilla = null;
            VentaDTO ventaObtenida = null;
            LineaCreditoTodoModel creditoPlanilla = null;
            decimal montoTotalConsumido = 0;
            decimal montoConsumidoActualDsctoPlanilla = 0;
            decimal montoFormaPagoDsctoPlanilla = 0;
            decimal montoTotalDsctoPlanilla = 0;

            var opcionProceso = venta.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create;
            var totalFormasPago = request.FormasPago?.Sum(x => x.Monto);

            if (totalFormasPago == 0)
            {
                throw new Exception("No existe Montos de forma de pago");
            }
            if (Math.Round(totalFormasPago ?? 0, 2) != Math.Round(request.ImporteTotal ?? 0, 2))
            {
                throw new Exception("El monto de forma de pago no coincide con el importe Total de la Venta");
            }

            // Validar que exista alguna forma de pago por descuento planilla (Id = 4)
            if (request.FormasPago?.Any(x => x.IdFormaPago == 4) == true)
            {
                if (request.IdPersona is null)
                    throw new ArgumentNullException(nameof(request.IdPersona),
                        "No se recibió el IdPersona para validar el crédito por descuento planilla.");

                creditoPlanilla = await _lineaCreditoQuery.ObtenerLineaCreditoPorIdPersonaAsync(request.IdPersona.Value);

                if (creditoPlanilla is null)
                    throw new InvalidOperationException("No se encontró información de crédito para la persona seleccionada.");

                if (!creditoPlanilla.activo)
                    throw new InvalidOperationException("La persona no está habilitada para compras por Descuento por Planilla.");

                formaPagoPlanilla = request.FormasPago.FirstOrDefault(x => x.IdFormaPago == 4)!;

                if (formaPagoPlanilla is null)
                    throw new InvalidOperationException("No se encontró la forma de pago por Planilla en la solicitud.");

                var disponible = creditoPlanilla.MontoCredito - creditoPlanilla.MontoConsumido;

                if (formaPagoPlanilla.Monto > disponible)
                    throw new InvalidOperationException("No existe suficiente crédito disponible para completar la compra por Descuento por Planilla.");
            }

            if (request.Id > 0)
            {
                ventaObtenida = await _repository.ObtenerVentaPorIdAsync(request.Id);

                if (ventaObtenida == null)
                    throw new Exception("La venta no existe.");

                if (ventaObtenida.IdUsuarioVendedor != request.IdUsuario)
                    throw new Exception("Solo el usuario que creó la venta puede editarla.");

                if (!ventaObtenida.Fecha.HasValue)
                    throw new Exception("La fecha de la venta no está definida.");

                if (ventaObtenida.Fecha.Value.Date != DateTime.Today)
                    throw new Exception("Solo se puede editar una venta en la fecha en que fue creada.");

                ventaObtenida.FormasPago = await _repository.ObtenerVentasFormaPagoPorIdVentaAsync(request.Id);    
            }


            // 1️. Construir la entidad
            venta = new VentaEntity(
                request.Id,
                request.Fecha,
                request.Hora,
                request.IdSede,
                request.TipoVenta,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersona,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,

                (request.Cantidad ?? 0),
                Math.Round((request.OpGravadas ?? 0), 2),
                Math.Round((request.OpExoneradas ?? 0), 2),
                Math.Round((request.OpInafectas ?? 0), 2),
                Math.Round((request.OpGratuitas ?? 0), 2),
                Math.Round((request.TotalDescuento ?? 0), 2),
                Math.Round((request.TotalIGV ?? 0), 2),
                Math.Round((request.TotalICBPER ?? 0), 2),
                Math.Round((request.ImporteTotal ?? 0), 2),

                request.IdUsuario
            );

            foreach (var d in request.Detalles ?? Enumerable.Empty<DetalleVentaCommand>())
            {
                venta.AgregarDetalle(
                    d.Id,
                    d.IdVenta,
                    d.IdProductoVariante,
                    d.IdTipoOperacion,
                    d.CodigoTipoOperacion,
                    d.Descripcion,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.AplicaICBP,
                    d.IdDescuento,
                    d.ValorDescuento,
                    d.SubTotal,
                    d.Activo
                );
            }

            foreach (var d in request.FormasPago ?? Enumerable.Empty<VentaFormaPagoCommand>())
            {
                venta.AgregarFormaPago(
                    d.Id,
                    d.IdVenta,
                    d.IdFormaPago,
                    d.Monto,
                    d.ReferenciaPago,
                    d.RutaIcono
                );
            }

            // 2. Guardar en BD (Dapper/SP)
            VentaEntity ventaRespuesta = await _repository.GuardarVentaAsync(venta);

            if (ventaRespuesta == null || ventaRespuesta.Id == 0)
            {
                throw new Exception("No se pudo registrar la Venta");
            }

            // 3. Aumetar o Descontar Monto Consumido en caso sea Pago con Descuento Planilla
            montoConsumidoActualDsctoPlanilla = ventaObtenida?.FormasPago?.FirstOrDefault(x => x.IdFormaPago == 4)?.Monto ?? 0;
            montoFormaPagoDsctoPlanilla = request.FormasPago?.FirstOrDefault(x => x.IdFormaPago == 4)?.Monto ?? 0;

            // Detectar si existe forma de pago planilla en cualquiera de las dos listas
            bool tieneDsctoPlanilla =
                montoConsumidoActualDsctoPlanilla > 0 ||
                montoFormaPagoDsctoPlanilla > 0;

            if (tieneDsctoPlanilla)
            {
                montoTotalConsumido = creditoPlanilla!.MontoConsumido;

                if (montoTotalConsumido == 0)
                {
                    montoTotalDsctoPlanilla = montoFormaPagoDsctoPlanilla;
                }
                else if (request.Id == 0)
                {
                    montoTotalDsctoPlanilla = montoTotalConsumido + montoFormaPagoDsctoPlanilla;
                }
                else
                {
                    montoTotalDsctoPlanilla = (montoTotalConsumido - montoConsumidoActualDsctoPlanilla) + montoFormaPagoDsctoPlanilla;
                }

                var rptaAsignarConsumido = await _lineaCreditoCommand.ProcesarAsync(new LineaCreditoModel
                {
                    Opcion = 3,
                    Id = request.IdPersona ?? 0,
                    MontoCredito = 0,
                    MontoConsumido = montoTotalDsctoPlanilla,
                    IdUsuario = request.IdUsuario ?? 0
                });

                if (rptaAsignarConsumido == 0)
                    throw new Exception("No se pudo actualizar el Monto Consumido del Descuento Planilla");
            }

            // Acciones luego del Insert Nuevo
            if (request.Id == 0)
            {
                //se debe crear su estado PENDIENTE
                int idReferencia = ventaRespuesta.Id;
                var estados = await _estadoRepository.ListarTodosAsync();
                var estadoPendiente = estados.Find(x => x.CodigoEstadosBase == "PEND" && x.IdTipoProceso == idTipoProceso && x.Activo);

                var parametroEstado = new DocumentoEstadoEntity(
                    0,
                    idTipoProceso,
                    idReferencia,
                    estadoPendiente?.Id,
                    request.IdUsuario
                );

                var respuestaEstado = await _documentoEstadoRepository.GuardarAsync(parametroEstado);

                if (respuestaEstado == null)
                {
                    throw new Exception("El estado de la venta no se registro correctamente");
                }
            }


            // Retornar un DTO
            return new VentaDTO
            {
                Id = ventaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Fecha = ventaRespuesta.Fecha,
                IdTipoComprobante = ventaRespuesta.IdTipoComprobante,
                Serie = ventaRespuesta.Serie,
                Numero = ventaRespuesta.Numero,
                IdPersona = ventaRespuesta.IdPersona,
                IdTipoMoneda = ventaRespuesta.IdTipoMoneda,
                IdUsuarioVendedor = ventaRespuesta.IdUsuarioVendedor,
                NombreVendedor = ventaRespuesta.NombreVendedor,

                Cantidad = ventaRespuesta.Cantidad,
                OpGravadas = ventaRespuesta.OpGravadas,
                OpExoneradas = ventaRespuesta.OpExoneradas,
                OpInafectas = ventaRespuesta.OpInafectas,
                OpGratuitas = ventaRespuesta.OpGratuitas,
                TotalDescuento = ventaRespuesta.TotalDescuento,
                TotalIGV = ventaRespuesta.TotalIGV,
                TotalICBPER = ventaRespuesta.TotalICBPER,
                ImporteTotal = ventaRespuesta.ImporteTotal,

                Detalles = ventaRespuesta.Detalles.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProductoVariante = x.IdProductoVariante,
                    IdTipoOperacion = x.IdTipoOperacion,
                    CodigoTipoOperacion = x.CodigoTipoOperacion,
                    Descripcion = x.Descripcion,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    AplicaICBP = x.AplicaICBP,
                    IdDescuento = x.IdDescuento,
                    ValorDescuento = x.ValorDescuento,
                    SubTotal = x.SubTotal,
                    Activo = x.Activo
                }).ToList(),

                FormasPago = ventaRespuesta.FormasPago.Select(x => new VentasFormaPagoDTO
                {
                    Id = x.Id,
                    IdVenta = x.IdVenta,
                    Monto = x.Monto,
                    ReferenciaPago = x.ReferenciaPago,
                    IdFormaPago = x.IdFormaPago,
                    RutaIcono = x.RutaIcono
                }).ToList(),

            };
        }


    }
}
