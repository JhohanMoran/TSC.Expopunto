using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/perfil-menu")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PerfilMenuController : Controller
    {
        private readonly IPerfilMenuCommand _perfilMenuCommand;
        private readonly IPerfilMenuQuery _perfilMenuQuery;
        public PerfilMenuController(IPerfilMenuCommand perfilMenuCommand, IPerfilMenuQuery perfilMenuQuery)
        {
            _perfilMenuCommand = perfilMenuCommand;
            _perfilMenuQuery = perfilMenuQuery;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPerfilesMenu([FromQuery] PerfilMenuParam param)
        {
            var data = await _perfilMenuQuery.ListarPerfilesMenuAsync(param);
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe perfiles menu")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("{idPerfil:int}/{idMenu:int}")]
        public async Task<IActionResult> ObtenerPerfilMenuPorPKs([FromRoute] int idPerfil, [FromRoute] int idMenu)
        {
            var data = await _perfilMenuQuery.ObtenerPerfilMenuPorPKsAsync(idPerfil, idMenu);
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe perfil menu")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] PerfilMenuModel model)
        {
            model.Opcion = (int)Common.OperationType.Create;
            await _perfilMenuCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, message: "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PerfilMenuModel model)
        {
            model.Opcion = (int)Common.OperationType.Update;
            await _perfilMenuCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, message: "Exitoso")
            );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] PerfilMenuModel model)
        {
            model.Opcion = (int)Common.OperationType.Delete;
            await _perfilMenuCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, message: "Exitoso")
            );
        }
    }
}
