using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;
using TSC.Expopunto.Application.DataBase.Perfil.Queries;
using TSC.Expopunto.Application.DataBase.Perfil.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/perfil")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PerfilController : Controller
    {

        private readonly IPerfilCommand _perfilCommand;
        private readonly IPerfilQuery _perfilQuery;
        public PerfilController(IPerfilCommand perfilCommand, IPerfilQuery perfilQuery)
        {
            _perfilCommand = perfilCommand;
            _perfilQuery = perfilQuery;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarPerfiles(
            [FromBody] PerfilesListaParametros parametro
        )
        {
            var data = await _perfilQuery.ListarPerfilesAsync(parametro);

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
        public async Task<IActionResult> ListarPerfilesPorEstado([FromQuery] bool? activo)
        {
            var data = await _perfilQuery.ListarPerfilesPorEstadoAsync(activo);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe menus")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-combo")]
        public async Task<IActionResult> ListarComboPerfiles()
        {
            var data = await _perfilQuery.ListarComboPerfilesAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe menus")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-por-id")]
        public async Task<IActionResult> ListarPerfilesPorIdAsync([FromQuery] int idPerfil)
        {
            if (idPerfil == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El id enviado no es valido")
                );
            }

            var data = await _perfilQuery.ListarPerfilesPorIdAsync(idPerfil);

            if (data == null)
            {
                return StatusCode(
                StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Perfil no encontrado")
                );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] PerfilModel model)
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _perfilCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PerfilModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
                );
            }

            model.Opcion = (int)OperationType.Update;
            var data = await _perfilCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] PerfilModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _perfilCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}
