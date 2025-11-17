using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;

namespace TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja
{
    public interface IDocumentoEstadoBajaRepository
    {
        Task<DocumentoEstadoBajaEntity> GuardarAsync(DocumentoEstadoBajaEntity parametros);
        Task<DocumentoEstadoBajaDTO> ObtenerDocumentoEstadoPorIdDocEstadoAsync(int idDocumentoEstado);
    }
}
