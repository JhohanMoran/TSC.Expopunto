using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Commands
{
    public class GuardarDocumentoEstadoBajaHandler : IRequestHandler<GuardarDocumentoEstadoBajaCommand, DocumentoEstadoBajaDTO?>
    {
        private readonly IDocumentoEstadoBajaRepository _repository;    
        public GuardarDocumentoEstadoBajaHandler(IDocumentoEstadoBajaRepository repository)
        {
            _repository = repository;
        }

        public Task<DocumentoEstadoBajaDTO?> Handle(GuardarDocumentoEstadoBajaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
