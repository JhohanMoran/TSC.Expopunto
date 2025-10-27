using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Parametro.Queries
{
    public class ParametroQuery : IParametroQuery
    {
        private readonly IDapperQueryService _dapperService;

        public ParametroQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        /// <summary>
        /// Lista parámetros con paginación.
        /// </summary>
        public async Task<List<ParametrosModel>> ListarParametrosAsync(ParametrosListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 1,
                pId = 0,
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina
            };

            var response = await _dapperService.QueryAsync<ParametrosModel>(
                "uspGetParametros",
                parameters
            );

            return response?.ToList() ?? new List<ParametrosModel>();
        }

        public async Task<List<ParametrosModel>> ListarParametrosPorCodigoAsync(ParametrosListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 3,
                pCodigosParametros = parametro.Codigos
            };

            var response = await _dapperService.QueryAsync<ParametrosModel>(
                "uspGetParametros",
                parameters
            );

            return response?.ToList() ?? new List<ParametrosModel>();
        }
    }
}
