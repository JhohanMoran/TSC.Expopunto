using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries
{
    public class ReporteQuery : IReporteQuery
    {
        private readonly IDapperQueryService _dapperService;

        public ReporteQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<ReporteModel>> ListarReportesAsync(ReportesListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 4,
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                pOrdenPor = parametro.OrdenarPor ?? "Fecha",
                pOrdenDireccion = parametro.OrdenDireccion ?? "ASC",
                pIdPersona = parametro.IdPersona ?? 0,
                pIdTipoComprobante = parametro.IdTipoComprobante ?? 0,
                pSerie = parametro.Serie,
                pNumero = parametro.Numero,
                pFechaInicio = parametro.FechaInicio?.Date,
                pFechaFin = parametro.FechaFin?.Date
            };

            var response = await _dapperService.QueryAsync<ReporteModel>(
                "uspGetVentas",
                parameters
            );

            return response?.ToList() ?? new List<ReporteModel>();
        }
    }
}
