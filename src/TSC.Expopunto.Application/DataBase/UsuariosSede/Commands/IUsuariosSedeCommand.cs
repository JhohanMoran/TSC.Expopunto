namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Commands
{
    public interface IUsuariosSedeCommand
    {
        Task ProcesarAsync(UsuariosSedeModel model);
    }
}
