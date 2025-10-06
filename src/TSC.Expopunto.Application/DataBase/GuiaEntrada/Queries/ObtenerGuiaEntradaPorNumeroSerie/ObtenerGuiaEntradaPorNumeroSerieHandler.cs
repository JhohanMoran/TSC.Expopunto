using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie
{
    public class ObtenerGuiaEntradaPorNumeroSerieHandler : IRequestHandler<ObtenerGuiaEntradaPorNumeroSerieQuery, GuiaEntradaDTO>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        public ObtenerGuiaEntradaPorNumeroSerieHandler(IGuiaEntradaRepository guiaEntradaRepository)
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
        }

        public async Task<GuiaEntradaDTO> Handle(ObtenerGuiaEntradaPorNumeroSerieQuery query, CancellationToken cancellationToken)
        {
            var param = new ObtenerGuiasEntradaParams
            {
                Opcion = query.Opcion,
                Numero = query.Numero,
                Serie = query.Serie
            };

            return await this._guiaEntradaRepository.ObtenerGuiaEntradaPorNumeroSerieAsync(param);
        }
    }
}
