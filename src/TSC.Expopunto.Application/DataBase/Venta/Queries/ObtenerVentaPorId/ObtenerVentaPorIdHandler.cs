using MediatR;
using TSC.Expopunto.Application.Interfaces.Venta;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorId
{
    public class ObtenerVentaPorIdHandler : IRequestHandler<ObtenerVentaPorIdQuery, VentaEntity>
    {
        private readonly IVentaRepository _repository;
        public ObtenerVentaPorIdHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<VentaEntity> Handle(ObtenerVentaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerVentaPorIdAsync(request.Id);
        }
    }
}
