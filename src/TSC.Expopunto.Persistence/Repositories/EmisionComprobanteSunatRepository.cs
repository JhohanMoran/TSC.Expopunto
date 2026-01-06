using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat.Params;
using TSC.Expopunto.Application.Interfaces.Repositories.EmisionComprobanteSunat;
using TSC.Expopunto.Domain.Entities.EmisionComprobanteSunat;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class EmisionComprobanteSunatRepository : IEmisionComprobanteSunatRepository
    {
        public readonly IDapperQueryService _dapperCommandService;
        public EmisionComprobanteSunatRepository(IDapperQueryService dapperCommandService)
        {
            _dapperCommandService = dapperCommandService;
        }
        public async Task<List<ComprobanteSunatEntity>> ObtenerComprobanteSunatAsync(ObtenerComprobanteSunatParams parametro)
        {
            var parameters = new
            {
                pIdVenta = parametro.IdVenta, 
                pIdUsuario = parametro.IdUsuario 
            };
            var response = await _dapperCommandService.QueryAsync<ComprobanteSunatEntity>("uspSetInsertaFacturaLocal", parameters);
            return response.ToList();
        }
    }
}
