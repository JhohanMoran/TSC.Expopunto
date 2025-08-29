using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/tipo-documento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]

    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoCommand _tipoDocumentoCommand;   

        public TipoDocumentoController(ITipoDocumentoCommand tipoDocumentoCommand)
        {
            _tipoDocumentoCommand = tipoDocumentoCommand;
        }

            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-Tipo-Documento")]
        public async Task<IActionResult> ObtenerTipoDocumento(
        [FromQuery] int idTipoDocumento)
        {
            if (idTipoDocumento == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status200OK, null, "El ID del tipo documento no es válido"));
            }

            var data = await _tipoDocumentoQuery.ObtenerTipoDocumentoPorIdAsync(idTipoDocumento);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el tipo documento"));


            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

    }
}
