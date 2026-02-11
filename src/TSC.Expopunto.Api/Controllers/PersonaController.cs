using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.Persona;
using TSC.Expopunto.Application.DataBase.Persona.Commands.RegistrarPersona;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.Persona.Queries.ObtenerPersonaPorNumDoc;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Authorize]
    [Route("api/v1/persona")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PersonaController : Controller
    {
        private readonly IPersonaQuery _personaQuery;
        private readonly IMediator _mediator;

        public PersonaController(IPersonaQuery personaQuery, IMediator mediator)
        {
            _personaQuery = personaQuery;
            _mediator = mediator;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarPersonas([FromBody] PersonasListaParametros parametro)
        {
            if (parametro.Pagina <= 0 || parametro.FilasPorPagina <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Parámetros de paginación inválidos")
                );
            }

            var data = await _personaQuery.ListarPersonasAsync(parametro);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("listar-combo")]
        public async Task<IActionResult> ListarComboPersonas()
        {
            var data = await _personaQuery.ListarComboPersonasAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No existen personas")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }


        [HttpPost("listar-por-id")]
        public async Task<IActionResult> ListarPersonaPorId([FromBody] IdParametro parametro)
        {
            Console.WriteLine($"ID RECIBIDO: {parametro?.IdPersona}");

            if (parametro.IdPersona <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id enviado no es válido")
                );
            }

            var data = await _personaQuery.ListarPersonasPorIdAsync(parametro.IdPersona);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }


        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] GuardarPersonaRequest request)
        {
            var command = new RegistrarPersonaCommand(
                (int)OperationType.Create,
                request.Id,
                request.CodTipoPersona,
                request.IdTipoDocumento,
                request.NumeroDocumento,
                request.RazonSocial,
                request.Nombres,
                request.Apellidos,
                request.Direccion,
                request.Celular,
                request.IdUsuario,
                request.Activo,
                request.DetalleMotivoBaja
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] GuardarPersonaRequest request)
        {
            if (request.Id == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de la Persona no es válido")
                );
            }

            var command = new RegistrarPersonaCommand(
                (int)OperationType.Update,
                request.Id,
                request.CodTipoPersona,
                request.IdTipoDocumento,
                request.NumeroDocumento,
                request.RazonSocial,
                request.Nombres,
                request.Apellidos,
                request.Direccion,
                request.Celular,
                request.IdUsuario,
                request.Activo,
                request.DetalleMotivoBaja
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] GuardarPersonaRequest request)
        {
            if (request.Id == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID Persona no es válido")
                );
            }

            var command = new RegistrarPersonaCommand(
                (int)OperationType.Delete,
                request.Id,
                request.CodTipoPersona,
                request.IdTipoDocumento,
                request.NumeroDocumento,
                request.RazonSocial,
                request.Nombres,
                request.Apellidos,
                request.Direccion,
                request.Celular,
                request.IdUsuario,
                request.Activo,
                request.DetalleMotivoBaja
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-consumido")]
        public async Task<IActionResult> ListarPersonasMontoConsumido([FromQuery] PersonasListaParametros parametro)
        {
            if (parametro.Pagina <= 0 || parametro.FilasPorPagina <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Parámetros de paginación inválidos")
                );
            }

            var data = await _personaQuery.ListarPersonasMontoConsumidoAsync(parametro);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe data")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("listar-modal-busqueda")]
        public async Task<IActionResult> ListarPersonasModalBusqueda([FromBody] PersonasListaParametros parametro)
        {
            var data = await _mediator.Send(new ObtenerPersonaPorNumDocQuery(parametro));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromBody] GuardarPersonaRequest request)
        {
            if (request.Id == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El idPersona no es válido")
                );
            }

            var command = new RegistrarPersonaCommand(
              4,
              request.Id,
              request.CodTipoPersona,
              request.IdTipoDocumento,
              request.NumeroDocumento,
              request.RazonSocial,
              request.Nombres,
              request.Apellidos,
              request.Direccion,
              request.Celular,
              request.IdUsuario,
              request.Activo,
              request.DetalleMotivoBaja
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
    }
}