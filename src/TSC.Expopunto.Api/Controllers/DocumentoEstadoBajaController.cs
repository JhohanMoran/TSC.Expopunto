using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/documento-estado-baja")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DocumentoEstadoBajaController : Controller
    {
        private readonly IMediator _mediator;
        public DocumentoEstadoBajaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("obtener-estado-baja-por-id-doc-estado/{idDocumentoEstado:int}")]
        public async Task<IActionResult> ObtenerEstadoBajaPorIdDocEstado(
          [FromRoute] int idDocumentoEstado
        )
        {
            var data = await _mediator.Send(new ObtenerEstadoBajaPorIdDocEstadoQuery(idDocumentoEstado));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}
