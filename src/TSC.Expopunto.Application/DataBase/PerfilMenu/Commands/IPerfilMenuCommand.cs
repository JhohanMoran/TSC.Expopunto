namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Commands
{
    public interface IPerfilMenuCommand
    {
        Task ProcesarAsync(PerfilMenuModel model);
    }
}
