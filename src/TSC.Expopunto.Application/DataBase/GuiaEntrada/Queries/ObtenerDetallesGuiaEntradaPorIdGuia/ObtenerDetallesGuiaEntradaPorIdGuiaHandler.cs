using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerDetallesGuiaEntradaPorIdGuia
{
    public class ObtenerDetallesGuiaEntradaPorIdGuiaComand : IRequestHandler<ObtenerDetallesGuiaEntradaPorIdGuiaQuery, List<DetalleGuiaEntradaDTO>>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        public ObtenerDetallesGuiaEntradaPorIdGuiaComand(IGuiaEntradaRepository guiaEntradaRepository)
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
        }

        public async Task<List<DetalleGuiaEntradaDTO>> Handle(ObtenerDetallesGuiaEntradaPorIdGuiaQuery request, CancellationToken cancellationToken)
        {
            return await _guiaEntradaRepository.ObtenerDetalleGuiaEntradaPorIdGuiaAsync(request.IdGuia);
        }
    }
}
