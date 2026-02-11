using TSC.Expopunto.Application.DataBase.UnidadMedida.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UnidadMedida.Queries
{
    public class UnidadMedidaQuery : IUnidadMedidaQuery
    {
        private readonly IDapperQueryService _dapperService;
        public UnidadMedidaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<UnidadesMedidaTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<UnidadesMedidaTodosModel>("uspGetUnidadesMedida",
            parameters);
            return response.ToList();
        }

        public async Task<UnidadesMedidaTodosModel> ObtenerUnidadMedidaPorIdAsync(int idUnidadMedida)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdUnidadMedida = idUnidadMedida
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<UnidadesMedidaTodosModel>("uspGetUnidadesMedida",
            parameters);
            return response;
        }
    }
}
