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
                pSede = parametro.Sede,
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
                "uspGetDetalleVenta",   // usa el nombre correcto del SP
                parameters
            );

            return response.ToList();
        }



    }
}
