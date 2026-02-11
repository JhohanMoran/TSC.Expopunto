using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoMoneda.Queries
{
    public interface ITipoMonedaQuery
    {
        Task<List<TiposMonedaTodosModel>> ListarTodosAsync();
        Task<TiposMonedaTodosModel> ObtenerTipoMonedaPorIdAsync(int idTipoMoneda);
    }
}
