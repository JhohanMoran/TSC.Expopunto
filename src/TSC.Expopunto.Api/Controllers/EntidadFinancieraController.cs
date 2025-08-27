using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;


namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/entidad-financiera")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EntidadFinancieraController : Controller
    {
        private readonly IEntidadFinancieraCommand _entidadFinancieraCommand;
        public EntidadFinancieraController(IEntidadFinancieraCommand entidadFinancieraCommand)
        {
            _entidadFinancieraCommand = entidadFinancieraCommand;

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] EntidadFinancieraModel model
        )
        {
            model.opcion = (int)OperationType.Create;
            var data = await _entidadFinancieraCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

    }
}
