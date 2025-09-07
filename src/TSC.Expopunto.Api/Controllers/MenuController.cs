using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TSC.Expopunto.Application.DataBase.Menu.Command;
using TSC.Expopunto.Application.DataBase.Menu.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/menu")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class MenuController : Controller
    {
        private readonly IMenuCommand _menuCommand;
        private readonly IMenuQuery _menuQuery;
        public MenuController(IMenuCommand menuCommand, IMenuQuery menuQuery)
        {
            _menuCommand = menuCommand;
            _menuQuery = menuQuery;
        }

        [HttpGet("listar-por-estado")]
        public async Task<IActionResult> ListarMenusPorEstados([FromQuery] bool? activo)
        {
            var data = await _menuQuery.ListarMenusPorEstadoAsync(activo);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe menus")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-submenus")]
        public async Task<IActionResult> ListarMenusSubMenusAsync()
        {
            var data = await _menuQuery.ListarMenusSubMenusAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe menus")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-submenus-plano")]
        public async Task<IActionResult> ListarMenusSubMenusPlanoAsync()
        {
            var data = await _menuQuery.ListarMenusSubMenusPlanoAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe menus")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-por-id/{idMenu:int}")]
        public async Task<IActionResult> ListarMenusPorIdAsync([FromRoute] int idMenu)
        {
            if (idMenu == 0)
            {
                return StatusCode(
                   StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id enviado no es valido")
               );
            }

            var data = await _menuQuery.ListarMenusPorIdAsync(idMenu);

            if(data == null)
            {
                return StatusCode(
                StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontró el menú.")
                );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] MenuModel model)
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _menuCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] MenuModel model)
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _menuCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] MenuModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El idUsuario no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _menuCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

    }
}
