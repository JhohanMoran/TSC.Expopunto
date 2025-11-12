using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;

namespace TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja
{
    public interface IDocumentoEstadoBajaRepository
    {
        Task<DocumentoEstadoBajaEntity> GuardarAsync(DocumentoEstadoBajaEntity parametros);
    }
}
