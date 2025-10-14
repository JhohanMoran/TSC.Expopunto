using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries
{
    public class CuotasDescuentoQuery : ICuotasDescuentoQuery
    {
        private readonly IDapperQueryService _dapperService;
        public CuotasDescuentoQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<CuotasDescuentoTodoModel>> ListarTodosAsync(CuotasDescuentoParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
                pFiltroNombre = param.Nombre,
                pSerie = param.Serie,
                pNumero = param.Numero,
                pFechaInicio = param.FechaInicio,
                pFechaFin = param.FechaFin,
                pIdTipoComprobante = param.IdTipoComprobante,
                pCodTipoTrabajador = param.CodTipoTrabajador
            };
            var response = await _dapperService.QueryAsync<CuotasDescuentoTodoModel>("uspGetVentaCuotasDescuento", parameters);
            return response.ToList();
        }

        public List<CuotasDescuentoExcelDto> ListarExcel(CuotasDescuentoParam parametros)
        {
            var parameters = new
            {
                pOpcion = 2,
                pOrdenColumna = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pFiltroNombre = parametros.Nombre,
                pSerie = parametros.Serie,
                pNumero = parametros.Numero,
                pFechaInicio = parametros.FechaInicio,
                pFechaFin = parametros.FechaFin,
                pIdTipoComprobante = parametros.IdTipoComprobante,
                pCodTipoTrabajador = parametros.CodTipoTrabajador
            };
            var response = _dapperService.Query<CuotasDescuentoExcelDto>("uspGetVentaCuotasDescuento", parameters);
            return response.ToList();
        }

        public List<CuotasSofyaExcelDto> ListarSofyaExcel(CuotasDescuentoParam parametros)
        {
            var parameters = new
            {
                pOpcion = 3,
                pOrdenColumna = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,
                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pFiltroNombre = parametros.Nombre,
                pSerie = parametros.Serie,
                pNumero = parametros.Numero,
                pFechaInicio = parametros.FechaInicio,
                pFechaFin = parametros.FechaFin,
                pIdTipoComprobante = parametros.IdTipoComprobante,
                pCodTipoTrabajador = parametros.CodTipoTrabajador
            };
            var response = _dapperService.Query<CuotasSofyaExcelDto>("uspGetVentaCuotasDescuento", parameters);
            return response.ToList();
        }
    }
}
