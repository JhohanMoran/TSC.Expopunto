using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ListarDescuentosPorIdPersona
{
    public class ListarDescuentosPorIdPersonaHandler : IRequestHandler<ListarDescuentosPorIdPersonaQuery, List<PersonaDescuentoDTO>>
    {
        private readonly IPersonaDescuentoRepository _repository;
        public ListarDescuentosPorIdPersonaHandler(IPersonaDescuentoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PersonaDescuentoDTO>> Handle(ListarDescuentosPorIdPersonaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListarDescuentosPorIdPersonaAsync(request.IdPersona);
        }
    }
}
