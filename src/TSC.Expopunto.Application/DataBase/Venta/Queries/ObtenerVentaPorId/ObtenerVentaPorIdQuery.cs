using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorId
{
    public record ObtenerVentaPorIdQuery(int Id) : IRequest<VentaDTO?>;
}
