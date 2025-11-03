namespace TSC.Expopunto.Application.DataBase.LineaCredito.Commands
{
    public interface ILineaCreditoCommand
    {
        Task ProcesarAsync(LineaCreditoModel model);
    }
}
