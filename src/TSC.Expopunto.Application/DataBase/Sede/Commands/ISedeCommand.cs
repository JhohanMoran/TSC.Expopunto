namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public interface ISedeCommand
    {
        Task<SedeModel> ProcesarAsync(SedeModel model);
    }
}
