using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/usuario-perfil")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UsuariosPerfilController : Controller
    {
        private readonly IUsuariosPerfilCommand _usuariosPerfilCommand;
        public UsuariosPerfilController(IUsuariosPerfilCommand usuariosPerfilCommand)
        {
            _usuariosPerfilCommand = usuariosPerfilCommand;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] UsuariosPerfilModel model)
        {
            model.Opcion = (int)OperationType.Create;
            await _usuariosPerfilCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, message: "Exitoso")
            );
        }

        //[HttpPost("actualizar")]
        //public async Task<IActionResult> Actualizar([FromBody] UsuariosPerfilModel model)
        //{
        //    model.Opcion = (int)OperationType.Update;
        //    await _usuariosPerfilCommand.ProcesarAsync(model);
        //    return StatusCode(
        //        StatusCodes.Status200OK,
        //        ResponseApiService.Response(StatusCodes.Status200OK, message: "Exitoso")
        //    );
        //}

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] UsuariosPerfilModel model)
        {
            model.Opcion = (int)OperationType.Delete;
            await _usuariosPerfilCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, message: "Exitoso")
            );
        }

    }
}
