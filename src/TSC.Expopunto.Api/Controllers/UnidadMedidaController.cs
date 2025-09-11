using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.UnidadMedida.Queries;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/unidad-medida")]
    [ApiController]

    public class UnidadMedidaController : Controller
    {
        private readonly IUnidadMedidaQuery _unidadMedidaQuery;

        public UnidadMedidaController(IUnidadMedidaQuery unidadMedidaQuery)
        {
            _unidadMedidaQuery = unidadMedidaQuery;
        }
        [HttpGet("listar")]
        public async Task<IActionResult> ListarUnidadesMedida()
        {
            var data = await _unidadMedidaQuery.ListarTodosAsync();
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten Unidades de Medida"));
            }
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }
        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerUnidadMedida(
            [FromQuery] int idUnidadMedida)
        {
            if (idUnidadMedida == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de Unidad de Medida no es válido"));
            }
            var data = await _unidadMedidaQuery.ObtenerUnidadMedidaPorIdAsync(idUnidadMedida);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró la unidad de medida"));

            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")

            );

        }
    }
}
