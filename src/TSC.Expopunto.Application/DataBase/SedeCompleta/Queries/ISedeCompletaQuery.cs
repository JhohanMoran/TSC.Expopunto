using TSC.Expopunto.Application.DataBase.SedeCompleta.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.SedeCompleta.Queries
{
    public interface ISedeCompletaQuery
    {
        Task<List<SedeCompletaReporteModel>> ListarReporteAsync(string? nombre = null);
        Task<SedeCompletaDetalleModel> ObtenerParaEditarAsync(int id);
    }
}
