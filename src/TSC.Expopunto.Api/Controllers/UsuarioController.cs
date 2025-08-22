using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
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

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
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

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
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

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar(
           [FromBody] int idUsuario
       )
        {
            if (idUsuario == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
                );
            }

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

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var data = await _usuarioQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("obtener-usuario-por-id")]
        public async Task<IActionResult> ObtenerUsuarioPorId(
         [FromQuery] int idUsuario
     )
        {
            if (idUsuario == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El ID de usuario no es válido")
                );
            }

            var data = await _usuarioQuery.ObtenerUsuarioPorIdAsync(idUsuario);

            if (data == null)
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
