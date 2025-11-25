using MediatR;
using TSC.Expopunto.Application.DataBase.MotivoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.MotivoBaja;

namespace TSC.Expopunto.Application.DataBase.MotivoBaja.Queries.ListarMotivosBaja
{
    public class ListarMotivosBajaHandler : IRequestHandler<ListarMotivosBajaQuery, List<MotivoBajaDTO>?>
    {
        private readonly IMotivoBajaRepository _repository;
        public ListarMotivosBajaHandler(IMotivoBajaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MotivoBajaDTO>?> Handle(ListarMotivosBajaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListarMotivosBaja();
        }
    }
}
