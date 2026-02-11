namespace TSC.Expopunto.Application.DataBase.LineaCredito.Commands
{
    public interface ILineaCreditoCommand
    {
        Task<int> ProcesarAsync(LineaCreditoModel model);
        Task<int> AplicarMontoConsumido(LineaCreditoModel model);
        Task<int> DescontarMontoConsumido(LineaCreditoModel model);
    }
}
