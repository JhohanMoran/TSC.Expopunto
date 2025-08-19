namespace TSC.Expopunto.Application.DataBase.Usuario.Commands
{
    public interface IUsuarioCommand
    {
        Task<UsuarioModel> ProcesarAsync(UsuarioModel model);
    }
}
