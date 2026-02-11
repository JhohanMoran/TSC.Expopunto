using TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries
{
    public interface ICuotasDescuentoQuery
    {
        Task<List<CuotasDescuentoTodoModel>> ListarTodosAsync(CuotasDescuentoParam param);
        List<CuotasDescuentoExcelDto> ListarExcel(CuotasDescuentoParam parametros);
        List<CuotasSofyaExcelDto> ListarSofyaExcel(CuotasDescuentoParam parametros);
    }
}
