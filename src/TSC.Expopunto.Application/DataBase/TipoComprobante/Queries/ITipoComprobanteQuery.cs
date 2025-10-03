using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoComprobante.Queries
{
    public interface ITipoComprobanteQuery
    {
        Task<List<TiposComprobanteTodosModel>> ListarTodosAsync();
        Task<TiposComprobanteTodosModel> ObtenerTipoComprobantePorIdAsync(int idTipoComprobante);
    }
}
