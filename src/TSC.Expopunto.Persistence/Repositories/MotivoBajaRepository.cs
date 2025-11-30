using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.MotivoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.MotivoBaja;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class MotivoBajaRepository : IMotivoBajaRepository
    {
        public readonly IDapperQueryService _dapperQueryService;

        public MotivoBajaRepository(IDapperQueryService dapperQueryService)
        {
            _dapperQueryService = dapperQueryService;
        }

        public async Task<List<MotivoBajaDTO>> ListarMotivosBaja()
        {
            var parameters = new
            {
                Opcion = 1
            };
            var response = await _dapperQueryService
                                .QueryAsync<MotivoBajaDTO>("uspGetMotivosBaja", parameters);

            return response.ToList();
        }
    }
}