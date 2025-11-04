using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Parametro.Queries
{
    public interface IParametroQuery
    {
        Task<List<ParametrosModel>> ListarParametrosAsync(ParametrosListaParametros parametro);
        Task<List<ParametrosModel>> ListarParametrosPorCodigoAsync(ParametrosListaParametros parametro);
        Task<ParametrosFormulaVenta> ObtenerParametrosFormulaVenta();

    }
}
