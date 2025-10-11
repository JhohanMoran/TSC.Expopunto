
using global::TSC.Expopunto.Application.Features;

using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Reporte.Queries;
using TSC.Expopunto.Application.DataBase.Reporte.Queries.Models;
using TSC.Expopunto.Application.Exceptions;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/reporte")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ReporteController : Controller
    {
        private readonly IReporteQuery _reporteQuery;

        public ReporteController(IReporteQuery reporteQuery)
        {
            _reporteQuery = reporteQuery;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarReportes([FromBody] ReportesListaParametros parametro)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(parametro));
            if (parametro.Pagina <= 0 || parametro.FilasPorPagina <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Parámetros de paginación inválidos")
                );
            }

            var data = await _reporteQuery.ListarReportesAsync(parametro);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No existen registros")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("detalle")]
        public async Task<IActionResult> GetDetalleVenta([FromBody] int idVenta)
        {
            var detalles = await _reporteQuery.ListarDetalleVentaAsync(idVenta);

            if (detalles == null || detalles.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, detalles, "No existen registros")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, detalles, "Exitoso")
            );
        }
    }
}