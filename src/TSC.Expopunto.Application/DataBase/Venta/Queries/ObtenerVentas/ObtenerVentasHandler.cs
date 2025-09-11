using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas
{
    public class ObtenerVentasHandler : IRequestHandler<ObtenerVentasQuery, PagedResult<VentaDTO>>
    {
        private readonly IVentaRepository _repository;

        public ObtenerVentasHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<VentaDTO>> Handle(ObtenerVentasQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerVentasAsync(request.Parametros);
        }
    }
}
