using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
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

        public GuardarVentaHandler(
            IVentaRepository repository,
            IEstadoRepository estadoRepository,
            IDocumentoEstadoRepository documentoEstadoRepository
        )
        {
            _repository = repository;
            _estadoRepository = estadoRepository;
            _documentoEstadoRepository = documentoEstadoRepository;
        }

        public async Task<VentaDTO> Handle(GuardarVentaCommand request, CancellationToken cancellationToken)
        {
            VentaEntity venta = new VentaEntity();
            int idTipoProceso = 2; // 1:GUIA - 2:VENTAS

            var opcionProceso = venta.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create;

            if (request.Id > 0)
            {
                var ventaObtenidaPorId = await _repository.ObtenerVentaPorIdAsync(request.Id);

                if (ventaObtenidaPorId == null)
                    throw new Exception("La venta no existe.");

                if (ventaObtenidaPorId.IdUsuarioVendedor != request.IdUsuario)
                    throw new Exception("Solo el usuario que creó la venta puede editarla.");

                if (!ventaObtenidaPorId.Fecha.HasValue)
                    throw new Exception("La fecha de la venta no está definida.");

                if (ventaObtenidaPorId.Fecha.Value.Date != DateTime.Today)
                    throw new Exception("Solo se puede editar una venta en la fecha en que fue creada.");
            }

            // 1️. Construir la entidad
            venta = new VentaEntity(
                request.Id,
                request.Fecha,
                request.Hora,
                request.IdSede,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersona,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,

                request.Cantidad,
                request.OpGravadas,
                request.OpExoneradas,
                request.OpInafectas,
                request.OpGratuitas,
                request.TotalDescuento,
                request.TotalIGV,
                request.TotalICBPER,
                request.ImporteTotal,
                
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

            // 3. Si es nuevo, se debe crear su estado PENDIENTE
            if (request.Id == 0)
            {
                int idReferencia = ventaRespuesta.Id;

                var estados = await _estadoRepository.ListarTodosAsync();
                var estadoPendiente = estados.Find(x => x.CodigoEstadosBase == "PEND" && x.Activo);

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
