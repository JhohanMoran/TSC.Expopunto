using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/tipo-documento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoQuery _tipoDocumentoQuery;

        public TipoDocumentoController(ITipoDocumentoQuery tipoDocumentoQuery)
        {
            _tipoDocumentoQuery = tipoDocumentoQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTiposDocumento()
        {
            var data = await _tipoDocumentoQuery.ListarTodosAsync();

            if (data == null || !data.Any())
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No existen tipos de documento")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerTipoDocumento(
        [FromQuery] int idTipoDocumento)
        {
            if (idTipoDocumento == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID del tipo documento no es válido"));
            }


            var data = await _tipoDocumentoQuery.ObtenerTipoDocumentoPorIdAsync(idTipoDocumento);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el tipo documento"));


            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}

