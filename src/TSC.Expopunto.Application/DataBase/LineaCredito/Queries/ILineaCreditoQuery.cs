using TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.LineaCredito.Queries
{
    public interface ILineaCreditoQuery
    {
        Task<List<LineaCreditoTodoModel>> ListarLineasCreditoAsync(LineaCreditoParam param);
        Task<LineaCreditoTodoModel> ObtenerLineaCreditoPorIdAsync(int id);
        Task<LineaCreditoTodoModel> ObtenerLineaCreditoPorIdPersonaAsync(int idPersona);
    }
}
