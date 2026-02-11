using TSC.Expopunto.Application.DataBase.MedioPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.MedioPago.Queries
{
    public class MedioPagoQuery : IMedioPagoQuery
    {
        private readonly IDapperQueryService _dapperService;

        public MedioPagoQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<MediosPagoTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<MediosPagoTodosModel>("uspGetMediosPago",
            parameters);
            return response.ToList();
        }

        public async Task<MediosPagoTodosModel> ObtenerMedioPagoPorIdAsync(int idMedioPago)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdMedioPago = idMedioPago
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<MediosPagoTodosModel>("uspGetMediosPago",
            parameters);
            return response;
        }

    }
}
