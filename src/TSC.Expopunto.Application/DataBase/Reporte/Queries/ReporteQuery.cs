using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries
{
    public class ReporteQuery : IReporteQuery
    {

        private readonly IDapperQueryService _dapperService;

        public ReporteQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<ReporteVentasModel>> ListarReportesAsync(ReportesListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 4,
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                pOrdenPor = parametro.OrdenarPor ?? "SerieNumero",
                pOrdenDireccion = parametro.OrdenDireccion ?? "ASC",
                pIdPersona = parametro.IdPersona ?? 0,
                pTipoComprobante = parametro.TipoComprobante,
                pSede=parametro.Sede,
                pSerie = parametro.Serie,
                pNumero = parametro.Numero,
                pFechaInicio = parametro.FechaInicio?.Date,
                pFechaFin = parametro.FechaFin?.Date
            };

            var response = await _dapperService.QueryAsync<ReporteVentasModel>(
                "uspGetVentas",
                parameters
            );

            return response?.ToList() ?? new List<ReporteVentasModel>();
        }
        public async Task<List<DetalleVentaDto>> ListarDetalleVentaAsync(int idVenta)
        {
            var parameters = new
            {
                pOpcion = 3,       // porque según tu SP, 1 = DETALLE POR VENTA
                pIdVenta = idVenta
            };

            var response = await _dapperService.QueryAsync<DetalleVentaDto>(
                "uspGetDetalleVenta",   
                parameters
            );

            return response.ToList();
        }

        public List<ReporteExcelDto> ListarExcel(ReportesListaParametros parametros)
        {
            var parameters = new
            {
                pOpcion = 5, // opción para exportar 
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor ?? "SerieNumero",
                pOrdenDireccion = parametros.OrdenDireccion ?? "ASC",
                pIdPersona = parametros.IdPersona ?? 0,
                pTipoComprobante = parametros.TipoComprobante,
                pSede = parametros.Sede,
                pSerie = parametros.Serie,
                pNumero = parametros.Numero,
                pFechaInicio = parametros.FechaInicio?.Date,
                pFechaFin = parametros.FechaFin?.Date
            };

            var response = _dapperService.Query<ReporteExcelDto>(
                "uspGetVentas",
                parameters
            );

            return response.ToList();
        }



    }
}
