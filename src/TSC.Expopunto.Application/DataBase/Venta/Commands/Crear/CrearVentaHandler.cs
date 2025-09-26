using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Crear
{
    public class CrearVentaHandler : IRequestHandler<CrearVentaCommand, VentaDTO>
    {
        private readonly IVentaRepository _repository;

        public CrearVentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaDTO> Handle(CrearVentaCommand request, CancellationToken cancellationToken)
        {
            VentaEntity venta = new VentaEntity();

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
                request.IdUsuario,
                true
            );

            foreach (var d in request.Detalles)
            {
                venta.AgregarDetalle(
                    d.Id,
                    d.IdVenta,
                    d.IdProducto,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.IdDescuento,
                    d.Activo
                );
            }

            // 2. Guardar en BD (Dapper/SP)
            VentaEntity ventaRespuesta = await _repository.CrearVentaAsync(venta);

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
                IdUsuario = ventaRespuesta.IdUsuario,
                Activo = ventaRespuesta.Activo,
                Detalles = ventaRespuesta.Detalles.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProducto = x.IdProducto,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    IdDescuento = x.IdDescuento,
                    Activo = x.Activo
                }).ToList()
            };
        }


    }
}
