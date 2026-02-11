using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries
{
    public interface IUsuarioQuery
    {
        Task<List<UsuariosTodosModel>> ListarTodosAsync(UsuarioParam param);
        Task<List<UsuariosTodosModel>> ListarTodosAsync();
        Task<UsuariosTodosModel> ObtenerUsuarioPorIdAsync(int idUsuario);
        Task<RespuestaLoginModel> ObtenerUsuarioPorUsuarioAsync(string usuario);
    }
}
