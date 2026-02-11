using TSC.Expopunto.Application.DataBase.MedioPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.MedioPago.Queries
{
    public interface IMedioPagoQuery
    {
        Task<List<MediosPagoTodosModel>> ListarTodosAsync();
        Task<MediosPagoTodosModel> ObtenerMedioPagoPorIdAsync(int idMedioPago);
    }
}
