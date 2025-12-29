using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSige.Params;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSige
{
    public record ObtenerGuiasConformeSigeQuery(ObtenerGuiasConformeSigeParams parametros) :  IRequest<PagedResult<GuiaConformeSigeDto>>;
}
