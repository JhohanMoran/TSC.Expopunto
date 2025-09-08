using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries
{
    public class UsuariosPerfilQuery : IUsuariosPerfilQuery
    {
        private readonly IDapperQueryService _dapperService;
        public UsuariosPerfilQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<UsuariosPerfilTodoModel>> ListarUsuariosPerfilesAsync(UsuariosPerfilParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdUsuario = param.IdUsuario,
                pIdPerfil = param.IdPerfil
            };
            var response = await _dapperService.QueryAsync<UsuariosPerfilTodoModel>("uspGetUsuariosPerfil", parameters);
            return response.ToList();
        }
        public async Task<UsuariosPerfilTodoModel> ObtenerUsuarioPerfilPorPKsAsync(int idUsuario, int idPerfil)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdUsuario = idUsuario,
                pIdPerfil = idPerfil
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<UsuariosPerfilTodoModel>("uspGetUsuariosPerfil", parameters);
            return response;
        }
    }
}
