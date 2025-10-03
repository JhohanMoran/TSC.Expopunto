using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;

namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Queries
{
    public record ObtenerDetalleVentaPorIdVentaQuery(int idVenta) : IRequest<List<DetalleVentaDTO>>;
}
