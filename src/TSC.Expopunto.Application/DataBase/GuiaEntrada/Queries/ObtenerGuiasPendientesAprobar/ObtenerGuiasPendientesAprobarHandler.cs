using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasPendientesAprobar
{
    public class ObtenerGuiasPendientesAprobarHandler : IRequestHandler<ObtenerGuiasPendientesAprobarQuery, PagedResult<GuiaEntradaDTO>>
    {
        private readonly IGuiaEntradaRepository _repository;
        public ObtenerGuiasPendientesAprobarHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResult<GuiaEntradaDTO>> Handle(ObtenerGuiasPendientesAprobarQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerGuiasPendientesAprobarAsync(request.parametros);
        }
    }
}
