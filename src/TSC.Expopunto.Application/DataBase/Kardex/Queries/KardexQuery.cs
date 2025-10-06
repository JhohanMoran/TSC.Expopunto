using TSC.Expopunto.Application.DataBase.Kardex.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Kardex.Queries
{
    public class KardexQuery : IKardexQuery
    {
        private readonly IDapperQueryService _dapperService;
        public KardexQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<KardexTodosModel>> ListarTodosAsync(KardexParam parametros)
        {
            var parameters = new
            {
                pOpcion = 1,
                pOrdenColumna = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pFiltroNombre = parametros.Nombre
            };
            var response = await _dapperService.QueryAsync<KardexTodosModel>("uspGetKardex", parameters);
            return response.ToList();

        }
        public List<KardexExcelDto> ListarExcel(KardexParam parametros)
        {
            var parameters = new
            {
                pOpcion = 2,
                pOrdenColumna = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pFiltroNombre = parametros.Nombre
            };
            var response = _dapperService.Query<KardexExcelDto>("uspGetKardex", parameters);
            return response.ToList();
        }
    }
}
