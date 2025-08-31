using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries.Models;
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
        private readonly IUsuariosPerfilQuery _usuariosPerfilQuery;
        public UsuariosPerfilController(IUsuariosPerfilCommand usuariosPerfilCommand, IUsuariosPerfilQuery usuariosPerfilQuery)
        {
            _usuariosPerfilCommand = usuariosPerfilCommand;
            _usuariosPerfilQuery = usuariosPerfilQuery;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuariosPerfil([FromQuery] UsuariosPerfilParam param)
        {
            var data = await _usuariosPerfilQuery.ListarUsuariosPerfilesAsync(param);
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios perfil")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("{idUsuario:int}/{idPerfil:int}")]
        public async Task<IActionResult> ObtenerUsuariosPerfilPorPKs([FromRoute] int idUsuario, [FromRoute] int idPerfil)
        {
            var data = await _usuariosPerfilQuery.ObtenerUsuarioPerfilPorPKsAsync(idUsuario, idPerfil);
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios perfil")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
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
