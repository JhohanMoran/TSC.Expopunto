using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        public UsuarioController(
            IUsuarioCommand usuarioCommand, 
            IUsuarioQuery usuarioQuery
        )
        {
            _usuarioCommand = usuarioCommand;
            _usuarioQuery = usuarioQuery;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] UsuarioModel model
        )
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _usuarioCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
            [FromBody] UsuarioModel model
        )
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _usuarioCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar(
           [FromBody] UsuarioModel model
        )
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _usuarioCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        /// <summary>
        /// Opción adicional y excepcional que no forma parte del CRUD estándar.
        /// Permite actualizar únicamente la contraseña del usuario.
        /// </summary>
        [HttpPost("actualizar-contrasenia")]
        public async Task<IActionResult> ActualizarContrasenia(
           [FromBody] UsuarioModel model
        )
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id no es válido")
                );
            }
            if (string.IsNullOrWhiteSpace(model.Contrasenia))
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "La contraseña no puede estar vacía")
                );
            }
            // opción adicional fuera del CRUD estándar (solo actualización de contraseña)
            model.Opcion = 4;
            var data = await _usuarioCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos([FromQuery] UsuarioParam param)
        {
            var data = await _usuarioQuery.ListarTodosAsync(param);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("obtener-por-id/{idUsuario:int}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(
         [FromRoute] int idUsuario
        )
        {

            if (idUsuario == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de usuario no es válido")
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
