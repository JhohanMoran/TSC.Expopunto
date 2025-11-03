using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries
{
    public interface IReporteQuery
    {
        Task<List<ReporteVentasModel>> ListarReportesAsync(ReportesListaParametros parametro);
        Task<List<DetalleVentaDto>> ListarDetalleVentaAsync(int idVenta);
        List<ReporteExcelDto> ListarExcel(ReportesListaParametros parametros);


    }
}