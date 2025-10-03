using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries
{
    public interface IReporteQuery
    {
        Task<List<ReporteVentasModel>> ListarReportesAsync(ReportesListaParametros parametro);
        Task<List<DetalleVentaDto>> ListarDetalleVentaAsync(int idVenta);

    }
}