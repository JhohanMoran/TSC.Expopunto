using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.VentaTipoOperacion.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.VentaTipoOperacion;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class VentaTipoOperacionRepository : IVentaTipoOperacionRepository
    {
        public readonly IDapperQueryService _dapperQueryService;

        public VentaTipoOperacionRepository(IDapperQueryService dapperQueryService)
        {
            _dapperQueryService = dapperQueryService;
        }

        public async Task<List<VentaTipoOperacionDTO>> ListarVentaTiposOperacion()
        {
            var parameters = new {};
            var response =
                await _dapperQueryService
                    .QueryAsync<VentaTipoOperacionDTO>("uspGetVentaTiposOperacion", parameters);
            return response.ToList();
        }

    }
}
