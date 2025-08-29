using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Queries
{
    public class PerfilMenuQuery : IPerfilMenuQuery
    {
        private readonly IDapperQueryService _dapperService;
        public PerfilMenuQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<PerfilMenuTodoModel>> ListarPerfilesMenuAsync(PerfilMenuParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdPerfil = param.IdPerfil,
                pIdMenu = param.IdMenu
            };
            var response = await _dapperService.QueryAsync<PerfilMenuTodoModel>("uspGetPerfilesMenu", parameters);
            return response.ToList();
        }

        public async Task<PerfilMenuTodoModel> ObtenerPerfilMenuPorPKsAsync(int idPerfil, int idMenu)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdPerfil = idPerfil,
                pIdMenu = idMenu
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<PerfilMenuTodoModel>("uspGetPerfilesMenu", parameters);
            return response;
        }
    }
}
