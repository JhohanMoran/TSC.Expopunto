using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasPendientesAprobar.Params;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasPendientesAprobar
{
    public record ObtenerGuiasPendientesAprobarQuery(ObtenerGuiasPendientesAprobarParams parametros) : IRequest<PagedResult<GuiaEntradaDTO>>;
}
