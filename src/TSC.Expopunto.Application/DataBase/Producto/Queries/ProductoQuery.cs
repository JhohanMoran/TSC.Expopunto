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

                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
                pFiltroActivo = param.Activo,
                pFiltroNombre = param.Nombre
            };

            var response = await _dapperQuerySevice.QueryAsync<ProductosTodos>("uspGetProductos", parametros);
            return response.ToList();

        }

        public async Task<ProductosTodos> ListarPorNombre(int opcion, int idCategoria, string nombre, string genero)
        {
            var parametros = new
            {
                pOpcion = opcion,
                pIdCategoria = idCategoria,
                pFiltroNombre = nombre,
                pGenero = genero
            };

            var response = await _dapperQuerySevice.QueryFirstOrDefaultAsync<ProductosTodos>("uspGetProductos", parametros);
            return response;
        }

        public async Task<List<ProductosVariantesTodos>> ListarProdVariantesAsync(ProductoParams param)
        {
            var parametros = new
            {
                pOpcion = 5,

                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
                pFiltroActivo = param.Activo,
                pFiltroNombre = param.Nombre
            };

            var response = await _dapperQuerySevice.QueryAsync<ProductosVariantesTodos>("uspGetProductos", parametros);
            return response.ToList();
        }

        public async Task<List<TallasTodos>> ListarTallasAsync()
        {
            var parametros = new
            {
                pOpcion = 6,
            };

            var response = await _dapperQuerySevice.QueryAsync<TallasTodos>("uspGetProductos", parametros);
            return response.ToList();
        }

        public async Task<List<ColoresTodos>> ListarColoresAsync()
        {
            var parametros = new
            {
                pOpcion = 7,
            };

            var response = await _dapperQuerySevice.QueryAsync<ColoresTodos>("uspGetProductos", parametros);
            return response.ToList();
        }
    }
}
