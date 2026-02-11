using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Queries
{
    public interface ITipoDocumentoQuery
    {
        Task<List<TiposDocumentoTodosModel>> ListarTodosAsync();
        Task<TiposDocumentoTodosModel> ObtenerTipoDocumentoPorIdAsync(int idTipoDocumento);
    }
}
