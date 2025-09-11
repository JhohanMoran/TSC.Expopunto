using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands
{
    public class VentaHandler : IRequestHandler<VentaCommand, VentaDTO>
    {
        private readonly IVentaRepository _repository;

        public VentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaDTO> Handle(VentaCommand request, CancellationToken cancellationToken)
        {
            VentaEntity venta = new VentaEntity();
            int ventaId = 0;

            if (request.Operation == OperationType.Create)
            {
                // 1️. Construir la entidad
                venta = new VentaEntity(
                    request.Id,
                    request.Fecha,
                    request.IdTipoComprobante,
                    request.Serie,
                    request.Numero,
                    request.IdPersonaCliente,
                    request.IdTipoMoneda,
                    request.IdUsuarioVendedor,
                    request.IdUsuario
                );

                foreach (var d in request.Detalles)
                {
                    venta.AgregarDetalle(
                        d.Id,
                        d.IdVenta,
                        d.IdProducto,
                        d.IdTalla,
                        d.Cantidad,
                        d.PrecioUnitario
                    );
                }

                // 2. Guardar en BD (Dapper/SP)
                ventaId = await _repository.CrearVentaAsync(venta);

                // Retornar un DTO
                return new VentaDTO
                {
                    Id = ventaId,
                    Fecha = venta.Fecha,
                    IdTipoComprobante = venta.IdTipoComprobante,
                    Serie = venta.Serie,
                    Numero = venta.Numero,
                    IdPersonaCliente = venta.IdPersonaCliente,
                    IdTipoMoneda = venta.IdTipoMoneda,
                    IdUsuarioVendedor = venta.IdUsuarioVendedor,
                    IdUsuario = venta.IdUsuario,

                    Detalles = venta.Detalles.Select(x => new DetalleVentaDTO
                    {
                        Id = x.Id,
                        IdVenta = x.IdVenta,
                        IdProducto = x.IdProducto,
                        IdTalla = x.IdTalla,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario
                    }).ToList()
                };

            }
            else if (request.Operation == OperationType.Update)
            {
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
                        d.PrecioUnitario
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
                    nuevosDetalles
                );

                // 3️. Guardar en BD
                ventaId = await _repository.ActualizarVentaAsync(ventaExistente);

                // Retornar un DTO
                return new VentaDTO
                {
                    Id = ventaId,
                    Fecha = ventaExistente.Fecha,
                    IdTipoComprobante = ventaExistente.IdTipoComprobante,
                    Serie = ventaExistente.Serie,
                    Numero = ventaExistente.Numero,
                    IdPersonaCliente = ventaExistente.IdPersonaCliente,
                    IdTipoMoneda = ventaExistente.IdTipoMoneda,
                    IdUsuarioVendedor = ventaExistente.IdUsuarioVendedor,
                    IdUsuario = ventaExistente.IdUsuario,

                    Detalles = ventaExistente.Detalles.Select(x => new DetalleVentaDTO
                    {
                        Id = x.Id,
                        IdVenta = x.IdVenta,
                        IdProducto = x.IdProducto,
                        IdTalla = x.IdTalla,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario
                    }).ToList()
                };

            }
            else if (request.Operation == OperationType.Delete)
            {
                // 1️. Recuperar venta existente

                var ventaExistente = await _repository.ObtenerVentaPorIdAsync(request.Id);

                if (ventaExistente is null)
                    throw new KeyNotFoundException($"No se encontró la venta con ID {request.Id}");

                ventaId = await _repository.EliminarVentaAsync(request.Id);

                // Retornar un DTO
                return new VentaDTO
                {
                    Id = ventaId,
                    Fecha = ventaExistente.Fecha,
                    IdTipoComprobante = ventaExistente.IdTipoComprobante,
                    Serie = ventaExistente.Serie,
                    Numero = ventaExistente.Numero,
                    IdPersonaCliente = ventaExistente.IdPersonaCliente,
                    IdTipoMoneda = ventaExistente.IdTipoMoneda,
                    IdUsuarioVendedor = ventaExistente.IdUsuarioVendedor,
                    IdUsuario = ventaExistente.IdUsuario,

                    Detalles = ventaExistente.Detalles.Select(x => new DetalleVentaDTO
                    {
                        Id = x.Id,
                        IdVenta = x.IdVenta,
                        IdProducto = x.IdProducto,
                        IdTalla = x.IdTalla,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario
                    }).ToList()
                };
            }
            else
            {
                throw new KeyNotFoundException($"Opción de proceso no válido");
            }
        }

    }
}
