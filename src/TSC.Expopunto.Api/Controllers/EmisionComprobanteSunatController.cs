using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat;
using TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat.Params;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/comprobante-sunat")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EmisionComprobanteSunatController : Controller
    {
        private readonly IMediator _mediator;
        public EmisionComprobanteSunatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("emitir")]
        public async Task<IActionResult> EmitirComprobanteSunat(
            [FromBody] ObtenerComprobanteSunatParams parametros
        )
        {
            await _mediator.Send(new ObtenerComprobanteSunatQuery(parametros));
            return StatusCode(
                StatusCodes.Status204NoContent,
                ResponseApiService.Response(StatusCodes.Status204NoContent, message:"Exitoso")
            );
        }
    }
}
