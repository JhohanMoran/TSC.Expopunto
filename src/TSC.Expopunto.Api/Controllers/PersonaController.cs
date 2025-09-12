using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Persona.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
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


        [HttpPost("listar")]
        public async Task<IActionResult> ListarPersonas([FromBody] PersonasListaParametros parametro)
        {
            var data = await _personaQuery.ListarPersonasAsync(parametro);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe data")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-por-estado")]
        public async Task<IActionResult> ListarPersonasPorEstado([FromQuery] bool? activo)
        {
            var data = await _personaQuery.ListarPersonasPorEstadoAsync(activo);

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

        [HttpGet("listar-combo")]
        public async Task<IActionResult> ListarComboPersonas()
        {
            var data = await _personaQuery.ListarComboPersonasAsync();

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

        [HttpGet("listar-por-id")]
        public async Task<IActionResult> ListarPersonaPorId([FromQuery] int idPersona)
        {
            if (idPersona == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El id enviado no es válido")
                );
            }

            var data = await _personaQuery.ListarPersonasPorIdAsync(idPersona);

            if (data == null)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Persona no encontrada")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] PersonaModel model)
        {
            model.Opcion = (int)OperationType.Create;

            var data = await _personaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PersonaModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status200OK, null, "El idPersona no es válido")
                );
            }

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
                    ResponseApiService.Response(StatusCodes.Status200OK, null, "El idPersona no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;
            var data = await _personaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}
