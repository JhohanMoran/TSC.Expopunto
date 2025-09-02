using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/persona")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PersonaController : Controller
    {
        private readonly IPersonaCommand _personaCommand;
        private readonly IPersonaQuery _personaQuery;
        public PersonaController(IPersonaCommand personaCommand, IPersonaQuery personaQuery)
        {
            _personaCommand = personaCommand;
            _personaQuery = personaQuery;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] PersonaModel model
        )
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _personaCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
            [FromBody] PersonaModel model
        )
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _personaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }


        [HttpPost("eliminar")]

        public async Task<IActionResult> Eliminar([FromBody] PersonaModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El id no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _personaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var data = await _personaQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existen personas")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
        [HttpPost("obtener-por-id")]
        public async Task<IActionResult> ObtenerPersonaPorId([FromQuery] int IdPersona
        )
        {
            if (IdPersona == 0)
            {

                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El Id de la persona no es válido")
                );
            }

            var data = await _personaQuery.ObtenerPersonaPorIdAsync(IdPersona);

            if (data == null)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Persona no encontrada")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

    }
}
