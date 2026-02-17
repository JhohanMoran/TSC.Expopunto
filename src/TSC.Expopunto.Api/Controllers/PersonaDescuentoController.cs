using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.PersonaDescuento;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ListarDescuentosPorIdPersona;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ObtenerDescuentoPersonaPorId;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Authorize]
    [Route("api/v1/persona-descuento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PersonaDescuentoController : Controller
    {
        private readonly IMediator _mediator;
        public PersonaDescuentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar(
            [FromBody] GuardarPersonaDescuentoRequest request
        )
        {
            var command = new GuardarPersonaDescuentoCommand(
                request.Id,
                request.IdPersona,
                request.FechaInicio.Value,
                request.FechaFin.Value,
                request.ValorDescuento,
                request.IdUsuario
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }


        [HttpGet("obtener-por-id/{id:int}")]
        public async Task<IActionResult> ObtenerDescuentoPersonaPorId(
           [FromRoute] int id
        )
        {
            var data = await _mediator.Send(new ObtenerDescuentoPersonaPorIdQuery(id));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-por-id-persona/{idPersona:int}")]
        public async Task<IActionResult> ListarDescuentosPorIdPersona(
           [FromRoute] int idPersona
        )
        {
            var data = await _mediator.Send(new ListarDescuentosPorIdPersonaQuery(idPersona));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("guardar-descuento-masivo")]
        public async Task<IActionResult> GuardarDescuentoMasivo(
         [FromBody] GuardarPersonasDsctoMasivoRequest request
        )
        {
            var command = new GuardarPersonaDsctoMasivoCommand(
                request.Id,
                request.IdPersona,
                request.FechaInicio.Value,
                request.FechaFin.Value,
                request.ValorDescuento,
                request.IdUsuario
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

    }
}
