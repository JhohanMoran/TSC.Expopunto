using TSC.Expopunto.Application.DataBase.FormaPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.FormaPago.Queries
{
    public interface IFormaPagoQuery
    {
        Task<List<FormasPagoTodosModel>> ListarTodosAsync();
        Task<FormasPagoTodosModel> ObtenerFormaPagoPorIdAsync(int idFormaPago);
    }
}
