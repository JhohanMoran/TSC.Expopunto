using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.VentaTipoOperacion.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/venta-tipo-operacion")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VentaTipoOperacionController : Controller
    {
        private readonly IMediator _mediator;
        public VentaTipoOperacionController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var data = await _mediator.Send(new ObtenerVentaTiposOperacionQuery());

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

    }
}
