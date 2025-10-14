using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.SedeSerie.Commands;
using TSC.Expopunto.Application.DataBase.SedeSerie.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/sede-serie")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SedeSerieController : Controller
    {
        private readonly ISedeSerieCommand _command;
        private readonly ISedeSerieQuery _query;

        public SedeSerieController(ISedeSerieCommand command, ISedeSerieQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] SedeSerieModel model)
        {

            model.Opcion = (int)OperationType.Create;
            var data = await _command.ProcesarAsync(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Registrado correctamente"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] SedeSerieModel model)
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _command.ProcesarAsync(model);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Actualizado correctamente"));
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "ID no válido"));

            var model = new SedeSerieModel
            {
                Id = id,
                Opcion = (int)OperationType.Delete,
                IdUsuario = 1 // Puedes reemplazar con usuario autenticado si aplica
            };

            var data = await _command.ProcesarAsync(model);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Eliminado correctamente"));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar([FromQuery] int? idSede = null)
        {
            var data = await _query.ListarAsync(idSede);
            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerPorId([FromQuery] int id)
        {
            var data = await _query.ObtenerPorIdAsync(id);
            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var data = await _query.ListarTodosAsync();
            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }
    }
}
