using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSigeDetalle.Params;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSigeDetalle
{
    public record ObtenerGuiasConformeSigeDetalleQuery(ObtenerGuiasConformeSigeDetalleParams parametros) : IRequest<PagedResult<GuiaConformeSigeDetalleDto>>;
}
