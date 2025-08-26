using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;
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
        public PerfilMenuController(IPerfilMenuCommand perfilMenuCommand)
        {
            _perfilMenuCommand = perfilMenuCommand;
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
