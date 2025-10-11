using TSC.Expopunto.Application.DataBase.UnidadMedida.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UnidadMedida.Queries
{
    public interface IUnidadMedidaQuery
    {
        Task<List<UnidadesMedidaTodosModel>> ListarTodosAsync();
        Task<UnidadesMedidaTodosModel> ObtenerUnidadMedidaPorIdAsync(int idUnidadMedida);
    }
}
