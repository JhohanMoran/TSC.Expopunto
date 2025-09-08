using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;


namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/entidad-financiera")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EntidadFinancieraController : Controller
    {
        private readonly IEntidadFinancieraCommand _entidadFinancieraCommand;
        private readonly IEntidadFinancieraQuery _entidadFinancieraQuery;
        public EntidadFinancieraController(IEntidadFinancieraCommand entidadFinancieraCommand, IEntidadFinancieraQuery entidadFinancieraQuery)
        {
            _entidadFinancieraCommand = entidadFinancieraCommand;
            _entidadFinancieraQuery = entidadFinancieraQuery;

        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] EntidadFinancieraModel model
        )
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _entidadFinancieraCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }
        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
            [FromBody] EntidadFinancieraModel model
        )
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _entidadFinancieraCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar(
            [FromBody] int IdEntidad
        )
        {
            if (IdEntidad == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El id de la Entidad no es válido")
                );
            }

            var model = new EntidadFinancieraModel()
            {
                Id = IdEntidad,
                Opcion = (int)OperationType.Delete

            };
            var data = await _entidadFinancieraCommand.ProcesarAsync(model);


            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }
        [HttpPost("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var data = await _entidadFinancieraQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)

            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe entidades")

                );

            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("obtener-por-id")]
        public async Task<IActionResult> ObtenerEntidadFinancieraPorId(
            [FromQuery] int IdEntidad
        )
        {
            if (IdEntidad == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El Id de la Entidad no es válido")
                );
            }

            var data = await _entidadFinancieraQuery.ObtenerEntidadFinancieraPorIdAsync(IdEntidad);

            if (data == null)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Entidad no encontrada")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }


    }
}
