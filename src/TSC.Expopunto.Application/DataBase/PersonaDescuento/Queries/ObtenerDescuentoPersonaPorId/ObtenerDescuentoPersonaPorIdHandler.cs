using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ObtenerDescuentoPersonaPorId
{
    public class ObtenerDescuentoPersonaPorIdHandler : IRequestHandler<ObtenerDescuentoPersonaPorIdQuery, PersonaDescuentoDTO>
    {
        private readonly IPersonaDescuentoRepository _repository;
        public ObtenerDescuentoPersonaPorIdHandler(IPersonaDescuentoRepository repository)
        {
            _repository = repository;
        }
        public async Task<PersonaDescuentoDTO> Handle(ObtenerDescuentoPersonaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerPersonaDescuentoPorIdAsync(request.Id);
        }
    }
}
