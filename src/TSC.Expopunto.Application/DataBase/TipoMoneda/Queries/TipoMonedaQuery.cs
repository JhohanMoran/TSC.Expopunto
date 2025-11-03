using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoMoneda.Queries
{
    public class TipoMonedaQuery : ITipoMonedaQuery
    {
        private readonly IDapperQueryService _dapperService;

        public TipoMonedaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<TiposMonedaTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<TiposMonedaTodosModel>("uspGetTiposMoneda",
            parameters);
            return response.ToList();

        }
        public async Task<TiposMonedaTodosModel> ObtenerTipoMonedaPorIdAsync(int idTipoMoneda)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdTipoMoneda = idTipoMoneda
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<TiposMonedaTodosModel>("uspGetTiposMoneda",
            parameters);
            return response;
        }

    }
}
