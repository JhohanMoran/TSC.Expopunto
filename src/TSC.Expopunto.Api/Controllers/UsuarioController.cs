using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioCommand _usuarioCommand;
        private readonly IUsuarioQuery _usuarioQuery;
        public UsuarioController(IUsuarioCommand usuarioCommand, IUsuarioQuery usuarioQuery)
        {
            _usuarioCommand = usuarioCommand;
            _usuarioQuery = usuarioQuery;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] UsuarioModel model
        )
        {
            model.opcion = (int)OperationType.Create;
            var data = await _usuarioCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(
            [FromBody] UsuarioModel model
        )
        {
            model.opcion = (int)OperationType.Update;
            var data = await _usuarioCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(
           [FromBody] int idUsuario
       )
        {
            var model = new UsuarioModel()
            {
                id = idUsuario,
                opcion = (int)OperationType.Delete
            };

            var data = await _usuarioCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            var data = await _usuarioQuery.ListarTodos();

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("GetUsuario")]
        public async Task<IActionResult> GetUsuario(
         [FromQuery] int idUsuario
     )
        {
            var data = await _usuarioQuery.GetUsuario(idUsuario);

            if(data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Usuario no encontrado")
               );

            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}
