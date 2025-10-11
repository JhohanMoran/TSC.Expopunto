using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands
{
    public class ActualizarVentaHandler : IRequestHandler<ActualizarVentaCommand, VentaDTO>
    {
        private readonly IVentaRepository _repository;

        public ActualizarVentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaDTO> Handle(ActualizarVentaCommand request, CancellationToken cancellationToken)
        {
            VentaEntity venta = new VentaEntity();

            // 1️. Recuperar venta existente
            var ventaExistente = await _repository.ObtenerVentaPorIdAsync(request.Id);

            if (ventaExistente is null)
                throw new KeyNotFoundException($"No se encontró la venta con ID {request.Id}");

            // 2️. Actualizar
            var nuevosDetalles = request.Detalles
                .Select(d => new DetalleVentaEntity(
                    d.Id,
                    d.IdVenta,
                    d.IdProductoVariante,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.IdDescuento,
                    d.Activo
                ))
                .ToList();

            var nuevasFormasPago = request.FormasPago
               .Select(d => new VentaFormasPagoEntity(
                   d.Id,
                   d.IdVenta,
                   d.IdFormaPago,
                   d.DescripcionFormaPago,
                   d.Monto,
                   d.ReferenciaPago
               ))
               .ToList();

            venta.Actualizar(
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
                request.IdUsuario,
                request.Activo,
                nuevosDetalles,
                nuevasFormasPago
            );

            // 3️. Guardar en BD
            VentaEntity ventaRespuesta = await _repository.ActualizarVentaAsync(venta);

            // 4. Retornar el detalle completo de la venta actualizada
            var ventaDetalleRespuesta = await _repository.ObtenerDetalleVentaPorIdVentaAsync(ventaRespuesta.Id);

            // 4. Retornar las formas de pago de la venta
            var ventaFormasPagoRespuesta = await _repository.ObtenerVentasFormaPagoPorIdVentaAsync(ventaRespuesta.Id);

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
                IdUsuario = ventaRespuesta.IdUsuario,
                Activo = ventaRespuesta.Activo,

                Detalles = ventaDetalleRespuesta.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProductoVariante = x.IdProductoVariante,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    IdDescuento = x.IdDescuento,
                    Activo = x.Activo
                }).ToList(),

                FormasPago = ventaFormasPagoRespuesta.Select(x => new VentasFormaPagoDTO
                {
                    Id = x.Id,
                    IdVenta = x.IdVenta,
                    VentaDescripcionFormaPago = x.VentaDescripcionFormaPago,
                    Monto = x.Monto,
                    ReferenciaPago = x.ReferenciaPago,
                    IdFormaPago = x.IdFormaPago,
                    FormaPago = x.FormaPago,
                    RutaIcono = x.RutaIcono,
                    Activo = x.Activo
                }).ToList(),
            };
        }

    }
}
