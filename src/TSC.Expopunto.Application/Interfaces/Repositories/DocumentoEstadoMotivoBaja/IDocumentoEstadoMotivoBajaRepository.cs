using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.DTO;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja
{
    public interface IDocumentoEstadoMotivoBajaRepository
    {
        Task<DocumentoEstadoMotivoBajaEntity> GuardarAsync(DocumentoEstadoMotivoBajaEntity parametros);
        Task<DocumentoEstadoBajaMotivoDTO> ObtenerMotivoBajaPorIdDocEstadoAsync(int idDocumentoEstado);
    }
}
