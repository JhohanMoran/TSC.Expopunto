using Microsoft.AspNetCore.Mvc;

using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;


namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/TipoComprobante")]
    [ApiController]
    public class TipoComprobanteController : Controller
    {
        private readonly ITipoComprobanteQuery _tipoComprobanteQuery;

        public TipoComprobanteController(ITipoComprobanteQuery tipoComprobanteQuery )
        {
            _tipoComprobanteQuery = tipoComprobanteQuery;
        }

        [HttpGet("listar-Tipos-Comprobante")]
        public async Task<IActionResult> ListarTiposComprobante()
        {
            var data = await _tipoComprobanteQuery.ListarTodosAsync();
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-Tipo-Comprobante")]
        public async Task<IActionResult> ObtenerTipoComprobante([FromQuery] int idTipoComprobante)
        {
            var data = await _tipoComprobanteQuery.ObtenerTipoComprobantePorIdAsync(idTipoComprobante);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el tipo Comprobante"));


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")


           );
        }
    }
}
