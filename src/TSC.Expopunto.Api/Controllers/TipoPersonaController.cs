using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoPersona.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/tipo-persona")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoPersonaController : Controller
    {

  
        private readonly ITipoPersonaQuery _tipoPersonaQuery;
        public TipoPersonaController(ITipoPersonaQuery tipoPersonaQuery)
        {
            
            _tipoPersonaQuery = tipoPersonaQuery;

        }
        [HttpPost("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var data = await _tipoPersonaQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)

            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe tipos de persona")

                );

            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("obtener-tipo-persona-por-id")]
        public async Task<IActionResult> ObtenerTipoPersonaPorId(
            [FromQuery] int IdTipoPersona
            )


        {
            if (IdTipoPersona == 0)
            {

                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El Id del tipo de persona no es válido")
                );
            }

            var data = await _tipoPersonaQuery.ObtenerTipoPersonaPorIdAsync(IdTipoPersona);

            if (data == null)

            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Tipo de persona no encontrada")

                );

            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
    }
}
