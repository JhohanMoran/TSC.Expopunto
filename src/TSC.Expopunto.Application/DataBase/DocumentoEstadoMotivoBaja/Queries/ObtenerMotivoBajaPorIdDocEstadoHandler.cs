using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.Queries
{
    public class ObtenerMotivoBajaPorIdDocEstadoHandler : IRequestHandler<ObtenerMotivoBajaPorIdDocEstadoQuery, DocumentoEstadoBajaMotivoDTO?>
    {
        private readonly IDocumentoEstadoMotivoBajaRepository _repository;
        public ObtenerMotivoBajaPorIdDocEstadoHandler(IDocumentoEstadoMotivoBajaRepository repository)
        {
            this._repository = repository;  
        }
        public async Task<DocumentoEstadoBajaMotivoDTO?> Handle(ObtenerMotivoBajaPorIdDocEstadoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerMotivoBajaPorIdDocEstadoAsync(request.IdDocumentoEstado);
        }
    }
}
