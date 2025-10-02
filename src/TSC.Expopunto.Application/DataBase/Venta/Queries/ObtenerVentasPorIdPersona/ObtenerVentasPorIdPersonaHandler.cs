using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentasPorIdPersona
{
    public class ObtenerVentasPorIdPersonaHandler : IRequestHandler<ObtenerVentasPorIdPersonaQuery, List<VentaMontoDTO>>
    {
        private readonly IVentaRepository _repository;
        public ObtenerVentasPorIdPersonaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<VentaMontoDTO>> Handle(ObtenerVentasPorIdPersonaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerVentasPorIdPersonaAsync(request.IdPersona);
        }
    }
}
