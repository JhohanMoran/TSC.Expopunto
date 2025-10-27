using MediatR;

namespace TSC.Expopunto.Application.Features.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie
{
    public record ObtenerGuiaEntradaPorNumeroSerieQueryPdf(int Opcion, string Numero, string Serie) : IRequest<byte[]?> { }
}
