using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries
{
    public class DescuentoProductoVarianteQuery : IDescuentoProductoVarianteQuery
    {
        private readonly IDapperQueryService _dapperService;

        public DescuentoProductoVarianteQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<DescuentoProductoVarianteModel>> ListarAsync(DescuentoProductoVarianteListaParametros parametros)
        {
            var parameters = new
            {
                pOpcion = 1,
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,
                pFiltroIdDescuento = parametros.FiltroIdDescuento,
                pFiltroIdVariante = parametros.FiltroIdVariante
            };

            var response = await _dapperService.QueryAsync<DescuentoProductoVarianteModel>(
                "uspGetDescuentoProductoVariantes", parameters);
                return response.ToList();
        }

        public async Task<List<DescuentoProductoVarianteModel>> ListarComboAsync()
        {
            var parameters = new 
            {
                pOpcion = 2 
            };
            var response = await _dapperService.QueryAsync<DescuentoProductoVarianteModel>(
                "uspGetDescuentoProductoVariantes", parameters);
                 return response.ToList();
        }

        public async Task<DescuentoProductoVarianteModel> ListarPorIdAsync(int id)
        {
            var parameters = new 
            { 
                pOpcion = 3, 
                pId = id 
            };
            return await _dapperService.QueryFirstOrDefaultAsync<DescuentoProductoVarianteModel>(
                "uspGetDescuentoProductoVariantes", parameters);
        }
    }
}
