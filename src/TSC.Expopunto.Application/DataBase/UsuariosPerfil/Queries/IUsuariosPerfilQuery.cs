using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries
{
    public interface IUsuariosPerfilQuery
    {
        Task<List<UsuariosPerfilTodoModel>> ListarUsuariosPerfilesAsync(UsuariosPerfilParam param);
        Task<UsuariosPerfilTodoModel> ObtenerUsuarioPerfilPorPKsAsync(int idUsuario, int idPerfil);
    }
}
