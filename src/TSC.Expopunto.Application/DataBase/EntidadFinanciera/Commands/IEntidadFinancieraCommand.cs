namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands
{
    public interface IEntidadFinancieraCommand
    {
        Task<EntidadFinancieraModel> ProcesarAsync(EntidadFinancieraModel model);

    }
}
