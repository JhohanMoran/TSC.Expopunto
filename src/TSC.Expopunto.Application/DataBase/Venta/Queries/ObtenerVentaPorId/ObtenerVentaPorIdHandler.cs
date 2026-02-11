using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorId
{
    public class ObtenerVentaPorIdHandler : IRequestHandler<ObtenerVentaPorIdQuery, VentaDTO>
    {
        private readonly IVentaRepository _repository;
        public ObtenerVentaPorIdHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaDTO> Handle(ObtenerVentaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerVentaPorIdAsync(request.Id);
        }
    }
}
