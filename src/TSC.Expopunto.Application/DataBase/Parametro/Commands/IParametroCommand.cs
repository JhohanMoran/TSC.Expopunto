namespace TSC.Expopunto.Application.DataBase.Parametro.Commands
{
    public interface IParametroCommand
    {
        Task<ParametroModel> ProcesarAsync(ParametroModel model);
    }
}
