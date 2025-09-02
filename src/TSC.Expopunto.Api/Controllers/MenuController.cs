using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Menu.Command;
using TSC.Expopunto.Application.DataBase.Menu.Queries;
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

        [HttpGet("listar-menus-por-estado")]
        public async Task<IActionResult> ListarMenusPorEstados([FromQuery] bool? activo)
        {
            var data = await _menuQuery.ListarMenusPorEstadoAsync(activo);

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

        [HttpGet("listar-menus-submenus")]
        public async Task<IActionResult> ListarMenusSubMenusAsync()
        {
            var data = await _menuQuery.ListarMenusSubMenusAsync();

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

        [HttpGet("listar-menus-por-id")]
        public async Task<IActionResult> ListarMenusPorIdAsync([FromQuery] int idMenu)
        {
            if (idMenu == 0)
            {
                return StatusCode(
                   StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El id enviado no es valido")
               );
            }

            var data = await _menuQuery.ListarMenusPorIdAsync(idMenu);

            if(data == null)
            {
                return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No se encontró el menú.")
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

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] MenuModel model)
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _menuCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
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
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
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
