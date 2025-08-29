using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/TipoMoneda")]
    [ApiController]
    public class TipoMonedaController : Controller
    {
        private readonly ITipoMonedaQuery _tipoMonedaQuery;

        public TipoMonedaController(ITipoMonedaQuery tipoMonedaQuery)
        {
            _tipoMonedaQuery = tipoMonedaQuery;
        }

        [HttpGet("listar-Tipos-Moneda")]
        public async Task<IActionResult> ListarTiposMoneda()
        {
            var data = await _tipoMonedaQuery.ListarTodosAsync();
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-Tipo-Moneda")]
        public async Task<IActionResult> ObtenerTipoMoneda([FromQuery] int idTipoMoneda)
        {
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
