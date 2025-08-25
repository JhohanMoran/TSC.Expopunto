using TSC.Expopunto.Application.DataBase.Accesos.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Accesos.Queries
{
    public interface IAccesosQuery
    {
        Task<IEnumerable<AccesosModel>> ObtenerMenuPorPerfilAsync(int idPerfil);
    }
}
