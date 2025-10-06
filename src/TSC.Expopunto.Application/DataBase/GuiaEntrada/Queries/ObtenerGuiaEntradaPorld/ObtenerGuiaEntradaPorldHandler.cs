using MediatR;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;
using static TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorld.ObtenerGuiaEntradaPorldQuery;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorId
{
    public class ObtenerGuiaEntradaPorIdHandler : IRequestHandler<ObtenerGuiaEntradaPorIdQuery, GuiaEntradaEntity>
    {
        private readonly IGuiaEntradaRepository _repository;
        public ObtenerGuiaEntradaPorIdHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<GuiaEntradaEntity> Handle(ObtenerGuiaEntradaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerGuiaEntradaPorIdAsync(request.Id);
        }
    }
}
