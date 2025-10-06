using TSC.Expopunto.Application.DataBase.Kardex.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Kardex.Queries
{
    public interface IKardexQuery
    {
        Task<List<KardexTodosModel>> ListarTodosAsync(KardexParam parametros);
        List<KardexExcelDto> ListarExcel(KardexParam parametros);
    }
}
