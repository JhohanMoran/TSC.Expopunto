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

        public async Task<List<UsuariosTodosModel>> ListarTodosAsync(UsuarioParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdUsuario = param.IdUsuario,
                pActivo = param.Activo,
                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
                pFiltroNombre = param.Nombre

            };
            var response = await _dapperService.QueryAsync<UsuariosTodosModel>("uspGetUsuarios", parameters);
            return response.ToList();
        }

        public async Task<UsuariosTodosModel> ObtenerUsuarioPorIdAsync(int idUsuario)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdUsuario = idUsuario
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<UsuariosTodosModel>("uspGetUsuarios", parameters);
            return response;
        }
    }
}
