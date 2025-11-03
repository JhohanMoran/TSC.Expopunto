namespace TSC.Expopunto.Application.DataBase.SedeSerie.Commands
{
    public interface ISedeSerieCommand
    {
        Task<SedeSerieModel> ProcesarAsync(SedeSerieModel model);
    }
}

