using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstado.Queries.ObtenerVentaEstadoPorId
{
    public class ObtenerDocumentoEstadoPorIdHandler : IRequestHandler<ObtenerDocumentoEstadoPorIdQuery, DocumentoEstadoDTO?>
    {
        private readonly IDocumentoEstadoRepository _repository;
        public ObtenerDocumentoEstadoPorIdHandler(IDocumentoEstadoRepository repository)
        {
            this._repository = repository;
        }
        public async Task<DocumentoEstadoDTO?> Handle(ObtenerDocumentoEstadoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerDocumentoEstadoPorIdAsync(request.Id);
        }
    }
}
