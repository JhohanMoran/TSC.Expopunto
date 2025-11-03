using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Application.Interfaces.Services;

namespace TSC.Expopunto.Application.Features.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie
{
    public class ObtenerGuiaEntradaPorNumeroSerieHandlerPdf : IRequestHandler<ObtenerGuiaEntradaPorNumeroSerieQueryPdf, byte[]?>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        private readonly IDocumentoPdfService _documentoService;
        public ObtenerGuiaEntradaPorNumeroSerieHandlerPdf(IGuiaEntradaRepository guiaEntradaRepository, IDocumentoPdfService documentoPdfService)
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
            this._documentoService = documentoPdfService;
        }

        public async Task<byte[]?> Handle(ObtenerGuiaEntradaPorNumeroSerieQueryPdf query, CancellationToken cancellationToken)
        {
            var param = new ObtenerGuiasEntradaParams
            {
                Opcion = query.Opcion,
                Numero = query.Numero,
                Serie = query.Serie
            };

            var response = await this._guiaEntradaRepository.ObtenerGuiaEntradaPorNumeroSerieAsync(param);
            // Generar PDF
            return _documentoService.GenerarGuiaEntradaPdf(response);
        }
    }
}
