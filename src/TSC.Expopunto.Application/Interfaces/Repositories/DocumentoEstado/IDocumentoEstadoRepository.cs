using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;
using TSC.Expopunto.Domain.Entities.DocumentoEstado;

namespace TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado
{
    public interface IDocumentoEstadoRepository
    {
        Task<DocumentoEstadoEntity> GuardarAsync(DocumentoEstadoEntity parametros);
        Task<bool> AprobarVentaAsync(DocumentoEstadoEntity documentoEstado, string idsJson);

        Task<DocumentoEstadoDTO> ObtenerDocumentoEstadoPorIdAsync(int id);
        Task<DocumentoEstadoDTO> ObtenerDocumentoEstadoPorIdReferenciaAsync(int tipoProceso, int idReferencia);
    }
}
