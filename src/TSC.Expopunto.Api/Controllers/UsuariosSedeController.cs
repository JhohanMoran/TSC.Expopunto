using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/usuario-sede")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UsuariosSedeController : Controller
    {
        private readonly IUsuariosSedeCommand _usuariosSedeCommand;
        private readonly IUsuariosSedeQuery _usuariosSedeQuery;
        public UsuariosSedeController(IUsuariosSedeCommand usuariosSedeCommand, IUsuariosSedeQuery usuariosSedeQuery)
        {
            _usuariosSedeCommand = usuariosSedeCommand;
            _usuariosSedeQuery = usuariosSedeQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarUsuariosSede([FromQuery] UsuariosSedeParam param)
        {
            var data = await _usuariosSedeQuery.ListarUsuariosSedesAsync(param);
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios sede")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("obtener-por-pks/{idUsuario:int}/{idSede:int}")]
        public async Task<IActionResult> ObtenerUsuariosSedePorPKs([FromRoute] int idUsuario, [FromRoute] int idSede)
        {
            var data = await _usuariosSedeQuery.ObtenerUsuarioSedePorPKsAsync(idUsuario, idSede);
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios sede")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] UsuariosSedeModel model)
        {
            model.Opcion = (int)Common.OperationType.Create;
            await _usuariosSedeCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, message: "Exitoso")
            );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] UsuariosSedeModel model)
        {
            model.Opcion = (int)Common.OperationType.Delete;
            await _usuariosSedeCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, message: "Exitoso")
            );
        }

    }
}
