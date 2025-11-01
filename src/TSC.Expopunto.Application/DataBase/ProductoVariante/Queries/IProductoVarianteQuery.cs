using TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries
{
    public interface IProductoVarianteQuery
    {
        Task<PagedResult<ProductosVariante>> ListarProductosVarianteTodosAsync(ProductosVarianteParametros parametro);
        Task<PagedResult<ProductosVarianteModel>> ListarProductosVarianteModelAsync(ProductosVarianteParametros parametro);
    }
}
