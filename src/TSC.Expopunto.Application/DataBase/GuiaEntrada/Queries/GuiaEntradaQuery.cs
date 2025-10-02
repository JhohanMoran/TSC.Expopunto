using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries
{
    public class GuiaEntradaQuery : IGuiaEntradaQuery
    {
        private readonly IDapperQueryService _dapperQueryService;

        public GuiaEntradaQuery(IDapperQueryService dapper)
        {
            this._dapperQueryService = dapper;
        }
        public async Task<List<ProveedoreGuiaEntadaDto>> GetProveedoresAsync(int opcion)
        {
            var param = new
            {
                pOpcion = opcion
            };

            return this._dapperQueryService.QueryAsync<ProveedoreGuiaEntadaDto>("uspGetGuiasEntrada", param, 0).Result.ToList();

        }
    }
}
