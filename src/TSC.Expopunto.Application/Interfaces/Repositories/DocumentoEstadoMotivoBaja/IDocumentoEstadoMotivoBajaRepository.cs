using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja
{
    public interface IDocumentoEstadoMotivoBajaRepository
    {
        Task<DocumentoEstadoMotivoBajaEntity> GuardarAsync(DocumentoEstadoMotivoBajaEntity parametros);
    }
}
