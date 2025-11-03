using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries
{
    public interface IEntidadFinancieraQuery
    {
        Task<List<EntidadeFinancieraTodosModel>> ListarTodosAsync();
        Task<EntidadeFinancieraTodosModel> ObtenerEntidadFinancieraPorIdAsync(int idEntidad);

    }
}
