using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.Estados.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Estado;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly IDapperQueryService _dapperQueryService;

        public EstadoRepository(IDapperQueryService dapperQueryService)
        {
            _dapperQueryService = dapperQueryService;
        }

        public async Task<List<EstadoDTO>> ListarTodosAsync()
        {
            var parameters = new
            {
                Opcion = 1
            };
            var response = await _dapperQueryService
                                .QueryAsync<EstadoDTO>("uspGetEstados", parameters);

            return response.ToList();
        }
    }
}
