using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;


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

        [HttpGet("listar-Tipos-Documento")]
        public async Task<IActionResult> ListarTiposDocumento()
        {
            var data = await _tipoDocumentoQuery.ListarTodosAsync();
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-Tipo-Documento")]
        public async Task<IActionResult> ObtenerTipoDocumento(
            [FromQuery] int idTipoDocumento)
        {
             var data = await _tipoDocumentoQuery.ObtenerTipoDocumentoPorIdAsync(idTipoDocumento);
             if (data == null)
             return StatusCode(StatusCodes.Status404NotFound,
             ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el tipo documento"));


             return StatusCode(StatusCodes.Status200OK,
             ResponseApiService.Response(StatusCodes.Status200OK,data, "Exitoso")
                
            var data = await _tipoDocumentoCommand.ProcesarAsync(model);
                
            );
        }

    }
}
