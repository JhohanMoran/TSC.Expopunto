using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorSerieNumero
{

    public class ObtenerVentaPorSerieNumeroHandler : IRequestHandler<ObtenerVentaPorSerieNumeroQuery, VentaDTO>
    {
        private readonly IVentaRepository _repository;
        public ObtenerVentaPorSerieNumeroHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaDTO> Handle(ObtenerVentaPorSerieNumeroQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerVentaPorSerieNumeroAsync(request.Serie, request.Numero);
        }
    }
}
