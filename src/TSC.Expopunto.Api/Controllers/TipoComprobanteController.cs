using Microsoft.AspNetCore.Mvc;

using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;


namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/tipo-comprobante")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoComprobanteController : Controller
    {
        private readonly ITipoComprobanteQuery _tipoComprobanteQuery;

        public TipoComprobanteController(ITipoComprobanteQuery tipoComprobanteQuery)
        {
            _tipoComprobanteQuery = tipoComprobanteQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTiposComprobante()
        {
            var data = await _tipoComprobanteQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten Tipos Comprobantes"));
            }


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerTipoComprobante(
            [FromQuery] int idTipoComprobante)
        {
            if (idTipoComprobante == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID del tipo comprobante no es válido"));
            }

            var data = await _tipoComprobanteQuery.ObtenerTipoComprobantePorIdAsync(idTipoComprobante);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}
