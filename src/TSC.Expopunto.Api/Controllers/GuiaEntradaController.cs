using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.GuiasEntrada;

using TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/guia-entrada")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class GuiaEntradaController : Controller
    {
        private readonly IMediator _mediator;

        public GuiaEntradaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] CrearGuiaEntradaRequest request
        )
        {
            var command = new CrearGuiaEntradaCommand(
                OperationType.Create,
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.IdPersonaProveedor,
                request.TipoGuia,
                request.Observacion,

                request.Detalles.Select(d => new DetalleGuiaEntradaCommand(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.IdTalla,
                    d.Cantidad,
                    d.CostoUnitario

                )).ToList()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
            [FromBody] ActualizarGuiaEntradaRequest request
        )
        {
            var command = new ActualizarGuiaEntradaCommand(
                OperationType.Update,
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.IdPersonaProveedor,
                request.TipoGuia,
                request.Observacion,
                request.Detalles.Select(d => new DetalleGuiaEntradaCommand(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.IdTalla,
                    d.Cantidad,
                    d.CostoUnitario
                )).ToList()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }



        [HttpPost("listar")]
        public async Task<IActionResult> Listar(
            [FromBody] ObtenerGuiasEntradaParams parametros
        )
        {
            var data = await _mediator.Send(new ObtenerGuiasEntradaQuery(parametros));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

    }
}

