using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/documento-estado-motivo-baja")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DocumentoEstadoMotivoBajaController : Controller
    {
        private readonly IMediator _mediator;
        public DocumentoEstadoMotivoBajaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("obtener-motivo-baja-por-id-doc-estado/{idDocumentoEstado:int}")]
        public async Task<IActionResult> ObtenerMotivoBajaPorIdDocEstado(
         [FromRoute] int idDocumentoEstado
       )
        {
            var data = await _mediator.Send(new ObtenerMotivoBajaPorIdDocEstadoQuery(idDocumentoEstado));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}
