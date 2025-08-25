using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly IDapperQueryService _dapperService;

        public UsuarioQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<UsuariosTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                p_opcion = 1
            };
            var response = await _dapperService.QueryAsync<UsuariosTodosModel>("uspGetUsuarios", parameters);
            return response.ToList();
        }

        public async Task<UsuariosTodosModel> ObtenerUsuarioPorIdAsync(int idUsuario)
        {
            var parameters = new
            {
                p_opcion = 2,
                p_idUsuario = idUsuario
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<UsuariosTodosModel>("uspGetUsuarios", parameters);
            return response;
        }
    }
}
