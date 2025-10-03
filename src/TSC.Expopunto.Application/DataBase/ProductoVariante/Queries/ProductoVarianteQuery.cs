using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries
{
    public class ProductoVarianteQuery : IProductoVarianteQuery
    {
        private readonly IDapperQueryService _dapperQuerySevice;

        public ProductoVarianteQuery(IDapperQueryService dapperQueryService)
        {
            _dapperQuerySevice = dapperQueryService;
        }

        public async Task<PagedResult<ProductosVariante>> ListarProductosVarianteTodosAsync(ProductosVarianteParametros parametro)
        {
            var parametros = new
            {
                pOpcion = 1,

                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                
                pFiltro = parametro.Filtro
            };

            var response = await _dapperQuerySevice.QueryAsync<ProductosVariante>("uspGetProductoVariante", parametros);

            var responseList = response.ToList();
            var totalRegistros = responseList.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<ProductosVariante>
            {
                Data = responseList,
                Total = totalRegistros,
                Pagina = parametro.Pagina,
                FilasPorPagina = parametro.FilasPorPagina
            };
        }
    }
}
