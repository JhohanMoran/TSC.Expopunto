using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly IDapperQueryService _dapperQuerySevice;

        public ProductoQuery(IDapperQueryService dapperQueryService)
        {
            _dapperQuerySevice = dapperQueryService;
        }
        public async Task<ProductosTodos> ListarPorIdAsync(int id)
        {
            var parametros = new
            {
                pOpcion = 3,
                pId = id
            };

            var response = await _dapperQuerySevice.QueryFirstOrDefaultAsync<ProductosTodos>("uspGetProductos", parametros);
            return response;
        }

        public async Task<List<ProductosTodos>> ListarActivosAsync()
        {
            var parametros = new
            {
                pOpcion = 2,
            };

            var response = await _dapperQuerySevice.QueryAsync<ProductosTodos>("uspGetProductos", parametros);
            return response.ToList();
        }

        public async Task<List<ProductosTodos>> ListarPaginadoAsync(ProductoParams param)
        {
            var parametros = new
            {
                pOpcion = 1,
                pFiltroActivo = param.Activo,
                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
                pFiltroNombre = param.Nombre
            };

            var response = await _dapperQuerySevice.QueryAsync<ProductosTodos>("uspGetProductos", parametros);
            return response.ToList();

        }
    }
}
