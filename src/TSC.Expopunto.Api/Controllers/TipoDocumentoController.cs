using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Commands;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/tipo-documento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]

    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoCommand _tipoDocumentoCommand;   

        public TipoDocumentoController(ITipoDocumentoCommand tipoDocumentoCommand)
        {
            _tipoDocumentoCommand = tipoDocumentoCommand;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] TipoDocumentoModel model
        )
        {
            model.opcion = (int)OperationType.Create;

            var data = await _tipoDocumentoCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

    }
}
