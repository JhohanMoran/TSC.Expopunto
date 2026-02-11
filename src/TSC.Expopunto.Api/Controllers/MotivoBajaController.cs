using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.MotivoBaja.Queries.ListarMotivosBaja;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Authorize]
    [Route("api/v1/motivo-baja")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class MotivoBajaController : Controller
    {
        private readonly IMediator _mediator;

        public MotivoBajaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var data = await _mediator.Send(new ListarMotivosBajaQuery());

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}
