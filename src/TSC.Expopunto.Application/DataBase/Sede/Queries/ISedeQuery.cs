using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;
namespace TSC.Expopunto.Application.DataBase.Sede.Queries
{
    public interface ISedeQuery
    {
        Task<List<SedesTodosModel>> ListarAsync(string? nombre = null);
        Task<List<SedesTodosModel>> ListarTodosAsync();
        Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede);
        
    }
}
