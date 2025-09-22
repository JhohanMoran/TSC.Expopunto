using TSC.Expopunto.Application.DataBase.Prendas.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Prendas.Queries
{
    public interface IPrendasQuery
    {
        Task<List<PrendasTodos>> ListarPaginadoStockAptAsync(PrendasParams param);
    }
}
