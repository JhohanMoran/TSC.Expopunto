namespace TSC.Expopunto.Application.DataBase.Menu.Command
{
    public interface IMenuCommand
    {
        Task<MenuModel> ProcesarAsync(MenuModel model);
    }
}
