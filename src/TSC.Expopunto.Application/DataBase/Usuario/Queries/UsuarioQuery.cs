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
            var response = await _dapperService.QueryAsync<UsuariosTodos>("uspUsuarioListados");
            return response.ToList();
        }

    }
}
