using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries
{
    public interface IProductoQuery
    {
        Task<List<ProductosTodos>> ListarPaginadoAsync(ProductoParams param);
        Task<List<ProductosTodos>> ListarActivosAsync();
        Task<ProductosTodos> ListarPorIdAsync(int id);
        Task<ProductosTodos> ListarPorNombre(int opcion, int idCategoria, string nombre, string genero);
        Task<List<ProductosVariantesTodos>> ListarProdVariantesAsync(ProductoParams param);
        Task<List<TallasTodos>> ListarTallasAsync();
        Task<List<ColoresTodos>> ListarColoresAsync();
        List<ProductosVariantesExcelDto> ListarProdVariantesExcel(ProductoParams param);
    }
}
