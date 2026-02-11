using TSC.Expopunto.Application.DataBase.Categoria.Queries.Models;
using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Categoria.Queries
{
    public interface ICategoriaQuery
    {
        Task<List<CategoriaTodos>> ListarPaginadoAsync(CategoriaParams param);
        Task<List<CategoriaTodos>> ListarActivosAsync();
        Task<CategoriaTodos> ListarPorIdAsync(int id);
        Task<CategoriaTodos> ListarPorNombreAsync(string nombre, int opcion);

    }
}
