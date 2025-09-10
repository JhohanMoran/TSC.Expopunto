using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries
{
    public interface IProductoQuery
    {
        Task<List<ProductosTodos>> ListarPaginadoAsync(ProductoParams param);
        Task<List<ProductosTodos>> ListarActivosAsync();
        Task<ProductosTodos> ListarPorIdAsync(int id);
    }
}
