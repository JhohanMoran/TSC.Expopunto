using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/tipo-moneda")]
    [ApiController]
    public class TipoMonedaController : Controller
    {
        private readonly ITipoMonedaQuery _tipoMonedaQuery;

        public TipoMonedaController(ITipoMonedaQuery tipoMonedaQuery)
        {
            _tipoMonedaQuery = tipoMonedaQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTiposMoneda()
        {
            var data = await _tipoMonedaQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten Tipos moneda"));
            }
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerTipoMoneda(
        [FromQuery] int idTipoMoneda)
        {

            if (idTipoMoneda == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status200OK, null, "El ID del tipo moneda no es válido"));
            }
            var data = await _tipoMonedaQuery.ObtenerTipoMonedaPorIdAsync(idTipoMoneda);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el tipo Moneda"));


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")


           );
        }
    }

}
