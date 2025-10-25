using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
using TSC.Expopunto.Application.DataBase.Sede.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/sede")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SedeController : Controller
    {
        private readonly ISedeCommand _sedeCommand;
        private readonly ISedeQuery _sedeQuery;

        public SedeController(ISedeCommand sedeCommand, ISedeQuery sedeQuery)
        {
            _sedeCommand = sedeCommand;
            _sedeQuery = sedeQuery;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] SedeModel model
            )
        {
            model.Opcion = (int)OperationType.Create;

            var data = await _sedeCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }


        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
             [FromBody] SedeModel model
            )
        {
            model.Opcion = (int)OperationType.Update;

            var data = await _sedeCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );


        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar(
             [FromBody] int idSede)
        {

            if (idSede == 0)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID no es válido"));

                //return StatusCode(
                //    StatusCodes.Status400BadRequest,
                //    ResponseApiService.Response(StatusCodes.Status200OK, null, "El ID de la sede  no es válido"));
            }

            var model = new SedeModel()
            {
                Id = idSede,
                Opcion = (int)OperationType.Delete
            };
            var data = await _sedeCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );


        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar([FromQuery] string? nombre = null)
        {
            var data = await _sedeQuery.ListarAsync(nombre);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
            );
        }


        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerSedePorId(
        [FromQuery] int idSede)
        {
            if (idSede == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de la sede no es válido"));
            }
            var data = await _sedeQuery.ObtenerSedePorIdAsync(idSede);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            var data = await _sedeQuery.ListarTodosAsync();

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
            );
        }
    }
}
