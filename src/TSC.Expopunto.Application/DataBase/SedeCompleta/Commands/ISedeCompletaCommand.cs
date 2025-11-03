namespace TSC.Expopunto.Application.DataBase.SedeCompleta.Commands
{
    public interface ISedeCompletaCommand
    {
        Task ProcesarAsync(SedeCompletaModel model);
    }
}