using TSC.Expopunto.Application.DataBase.UsuariosSede.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Queries
{
    public class UsuariosSedeQuery : IUsuariosSedeQuery
    {
        private readonly IDapperQueryService _dapperService;
        public UsuariosSedeQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<UsuariosSedeTodoModel>> ListarUsuariosSedesAsync(UsuariosSedeParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdUsuario = param.IdUsuario,
                pIdSede = param.IdSede
            };
            var response = await _dapperService.QueryAsync<UsuariosSedeTodoModel>("uspGetUsuariosSede", parameters);
            return response.ToList();
        }

        public async Task<UsuariosSedeTodoModel> ObtenerUsuarioSedePorPKsAsync(int idUsuario, int idSede)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdUsuario = idUsuario,
                pIdSede = idSede
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<UsuariosSedeTodoModel>("uspGetUsuariosSede", parameters);
            return response;
        }
    }
}
