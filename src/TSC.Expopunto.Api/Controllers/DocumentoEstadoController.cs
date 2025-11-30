using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.Queries.ObtenerVentaEstadoPorIdVenta;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/documento-estado")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DocumentoEstadoController : Controller
    {
        private readonly IMediator _mediator;
        public DocumentoEstadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("obtener-venta-estado-por-id-venta/{idVenta:int}")]
        public async Task<IActionResult> ObtenerVentaEstadoPorIdVenta(
           [FromRoute] int idVenta
        )
        {
            var data = await _mediator.Send(new ObtenerVentaEstadoPorIdVentaQuery(idVenta));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

    }
}
