using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoComprobante.Queries
{
    public class TipoComprobanteQuery : ITipoComprobanteQuery
    {
        private readonly IDapperQueryService _dapperService;

        public TipoComprobanteQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<TiposComprobanteTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<TiposComprobanteTodosModel>("uspGetTiposComprobante",
            parameters);
            return response.ToList();
        }

        public async Task<TiposComprobanteTodosModel> ObtenerTipoComprobantePorIdAsync(int idTipoComprobante)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdTipoComprobante = idTipoComprobante
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<TiposComprobanteTodosModel>("uspGetTiposComprobante",
            parameters);
            return response;
        }
    }
}
