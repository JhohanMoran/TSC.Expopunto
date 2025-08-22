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

        public async Task<List<UsuariosTodos>> ListarTodos()
        {
            var parameters = new
            {
                Opcion = 1
            };
            var response = await _dapperService.QueryAsync<UsuariosTodos>("uspUsuarioListados", parameters);
            return response.ToList();
        }

        public async Task<UsuariosTodos> GetUsuario(int idUsuario)
        {
            var parameters = new
            {
                Opcion = 2,
                IdUsuario = idUsuario
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<UsuariosTodos>("uspUsuarioListados", parameters);
            return response;
        }
    }
}
