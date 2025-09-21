using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada
{
    public record ObtenerGuiasEntradaQuery(ObtenerGuiasEntradaParams Parametros) : IRequest<PagedResult<GuiaEntradaDTO>>;
}