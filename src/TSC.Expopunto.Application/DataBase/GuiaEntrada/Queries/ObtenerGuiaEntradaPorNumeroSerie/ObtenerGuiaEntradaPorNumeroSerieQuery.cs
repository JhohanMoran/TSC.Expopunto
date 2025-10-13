using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie
{
    public record ObtenerGuiaEntradaPorNumeroSerieQuery(int Opcion, string Numero, string Serie) : IRequest<GuiaEntradaDTO> { }
}
