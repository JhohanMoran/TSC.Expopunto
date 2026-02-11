using TSC.Expopunto.Application.DataBase.FormaPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.FormaPago.Queries
{
    public class FormaPagoQuery : IFormaPagoQuery
    {
        private readonly IDapperQueryService _dapperService;

        public FormaPagoQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<FormasPagoTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<FormasPagoTodosModel>("uspGetFormasPago",
            parameters);
            return response.ToList();
        }

        public async Task<FormasPagoTodosModel> ObtenerFormaPagoPorIdAsync(int idFormaPago)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdFormaPago = idFormaPago
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<FormasPagoTodosModel>("uspGetFormasPago",
            parameters);
            return response;
        }

    }
}
