namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public interface IDescuentoCommand
    {
        Task<DescuentoModel> ProcesarAsync(DescuentoModel model);
    }
}
