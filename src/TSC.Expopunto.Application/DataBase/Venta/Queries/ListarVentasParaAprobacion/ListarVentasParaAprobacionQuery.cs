using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaAprobacion
{
    public record ListarVentasParaAprobacionQuery(DateTime fecha) : IRequest<List<VentaAprobacionDTO>>;
}
