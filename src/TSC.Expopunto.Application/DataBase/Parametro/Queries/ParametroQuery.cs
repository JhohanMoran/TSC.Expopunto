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
        public async Task<List<ParametrosModel>> ListarParametrosAsync()
        {
            var parameters = new
            {
                pOpcion = 1,
            };

            var response = await _dapperService.QueryAsync<ParametrosModel>("uspGetParametros", parameters);
            return response.ToList();
        }
    }
}
