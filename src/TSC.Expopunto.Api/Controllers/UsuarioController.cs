using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
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
        public UsuarioController(IUsuarioCommand usuarioCommand)
        {
            _usuarioCommand = usuarioCommand;
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

    }
}
