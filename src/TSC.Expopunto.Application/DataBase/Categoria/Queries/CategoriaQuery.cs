using TSC.Expopunto.Application.DataBase.Categoria.Queries.Models;
using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Categoria.Queries
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly IDapperQueryService _dapperQuerySevice;

        public CategoriaQuery(IDapperQueryService dapperQueryService)
        {
            _dapperQuerySevice = dapperQueryService;
        }
        public async Task<List<CategoriaTodos>> ListarActivosAsync()
        {
            var parametros = new
            {
                pOpcion = 2
            };

            var respnse = await _dapperQuerySevice.QueryAsync<CategoriaTodos>("uspGetCategorias", parametros);
            return respnse.ToList();
        }

        public async Task<List<CategoriaTodos>> ListarPaginadoAsync(CategoriaParams param)
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

            var respnse = await _dapperQuerySevice.QueryAsync<CategoriaTodos>("uspGetCategorias", parametros);
            return respnse.ToList();
        }

        public async Task<CategoriaTodos> ListarPorIdAsync(int id)
        {
            var parametros = new
            {
                pOpcion = 1,
                pId = id
            };

            var respnse = await _dapperQuerySevice.QueryFirstOrDefaultAsync<CategoriaTodos>("uspGetCategorias", parametros);
            return respnse;
        }
    }
}
