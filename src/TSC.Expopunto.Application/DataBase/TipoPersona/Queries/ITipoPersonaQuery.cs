using TSC.Expopunto.Application.DataBase.TipoPersona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoPersona.Queries
{
    public interface ITipoPersonaQuery
    {
        Task<List<TipoPersonaTodosModel>> ListarTodosAsync();
        Task<TipoPersonaTodosModel> ObtenerTipoPersonaPorCodigoAsync(string codigo);
    }
}
