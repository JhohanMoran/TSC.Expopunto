using TSC.Expopunto.Application.DataBase.Menu.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Menu.Queries
{
    public interface IMenuQuery
    {
        Task<List<MenusTodos>> ListarMenusPorEstadoAsync(bool? activo);
        Task<List<MenusTodos>> ListarMenusSubMenusAsync();
        Task<MenusTodos> ListarMenusPorIdAsync(int idMenu);
        Task<List<MenusTodos>> ListarMenusSubMenusPlanoAsync();
    }
}
