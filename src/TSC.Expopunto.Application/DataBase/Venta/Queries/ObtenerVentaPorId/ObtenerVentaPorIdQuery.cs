using MediatR;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorId
{
    public record ObtenerVentaPorIdQuery(int Id) : IRequest<VentaEntity?>;
}
    