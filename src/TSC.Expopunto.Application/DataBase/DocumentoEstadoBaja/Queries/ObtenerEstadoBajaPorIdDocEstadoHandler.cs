using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Queries
{
    public class ObtenerEstadoBajaPorIdDocEstadoHandler : IRequestHandler<ObtenerEstadoBajaPorIdDocEstadoQuery, DocumentoEstadoBajaDTO?>
    {
        private readonly IDocumentoEstadoBajaRepository _repository;

        public ObtenerEstadoBajaPorIdDocEstadoHandler(IDocumentoEstadoBajaRepository repository)
        {
            this._repository = repository;
        }
        public async Task<DocumentoEstadoBajaDTO?> Handle(ObtenerEstadoBajaPorIdDocEstadoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerDocumentoEstadoPorIdDocEstadoAsync(request.IdDocumentoEstado);
        }
    }
}
