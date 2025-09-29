using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries
{
    public interface IReporteQuery
    {
        Task<List<ReporteModel>> ListarReportesAsync(ReportesListaParametros parametro);
    }
}