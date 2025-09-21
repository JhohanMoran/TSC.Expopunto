using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;
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
                    d.IdProducto,
                    d.IdTalla,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Activo
                ))
                .ToList();

            ventaExistente.Actualizar(
                request.Id,
                request.Fecha,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersonaCliente,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,
                request.IdUsuario,
                request.Activo, 
                nuevosDetalles
            );

            // 3️. Guardar en BD
            VentaEntity ventaRespuesta = await _repository.ActualizarVentaAsync(ventaExistente);

            // 4. Retornar el detalle completo de la venta actualizada
            var ventaDetalleRespuesta = await _repository.ObtenerDetalleVentaPorIdVentaAsync(ventaRespuesta.Id);


            return new VentaDTO
            {
                Id = ventaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Fecha = ventaRespuesta.Fecha,
                IdTipoComprobante = ventaRespuesta.IdTipoComprobante,
                Serie = ventaRespuesta.Serie,
                Numero = ventaRespuesta.Numero,
                IdPersonaCliente = ventaRespuesta.IdPersonaCliente,
                IdTipoMoneda = ventaRespuesta.IdTipoMoneda,
                IdUsuarioVendedor = ventaRespuesta.IdUsuarioVendedor,
                IdUsuario = ventaRespuesta.IdUsuario,
                Activo = ventaRespuesta.Activo, 

                Detalles = ventaDetalleRespuesta.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProducto = x.IdProducto,
                    IdTalla = x.IdTalla,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    Activo = x.Activo   
                }).ToList()
            };
        }

    }
}
