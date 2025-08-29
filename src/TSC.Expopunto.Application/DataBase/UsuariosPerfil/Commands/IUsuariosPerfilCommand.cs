namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands
{
    public interface IUsuariosPerfilCommand
    {
        Task ProcesarAsync(UsuariosPerfilModel model);
    }
}
