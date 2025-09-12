using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas
{
    public record ObtenerVentasQuery(ObtenerVentasParams Parametros) : IRequest<PagedResult<VentaDTO>>;
}
