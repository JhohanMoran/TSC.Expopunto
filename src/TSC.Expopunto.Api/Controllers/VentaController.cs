using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.Ventas;
using TSC.Expopunto.Application.DataBase.Venta.Commands;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/venta")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VentaController : Controller
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] CrearVentaRequest request
        )
        {
            //var validate = await validator.ValidateAsync(request);

            //if (!validate.IsValid)
            //{
            //    return StatusCode(
            //        StatusCodes.Status400BadRequest,
            //        ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors)
            //    );
            //}

            var command = new VentaCommand(
                OperationType.Create,
                request.Id,
                request.Fecha,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersonaCliente,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,
                request.IdUsuario,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProducto,
                    d.IdTalla,
                    d.Cantidad,
                    d.PrecioUnitario
                )).ToList()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar(
            [FromBody] ActualizarVentaRequest request
        )
        {
            //var validate = await validator.ValidateAsync(request);

            //if (!validate.IsValid)
            //{
            //    return StatusCode(
            //        StatusCodes.Status400BadRequest,
            //        ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors)
            //    );
            //}

            var command = new VentaCommand(
                OperationType.Update,
                request.Id,
                request.Fecha,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersonaCliente,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,
                request.IdUsuario,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProducto,
                    d.IdTalla,
                    d.Cantidad,
                    d.PrecioUnitario
                )).ToList()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar(
            [FromBody] EliminarVentaRequest request
            //[FromServices] IValidator<EliminarVentaRequest> validator
        )
        {
            //var validate = await validator.ValidateAsync(request);

            //if (!validate.IsValid)
            //{
            //    return StatusCode(
            //        StatusCodes.Status400BadRequest,
            //        ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors)
            //    );
            //}

            var command = new VentaCommand(
                OperationType.Delete,
                request.Id,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                new List<DetalleVentaCommand>()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }


        [HttpPost("listar")]
        public async Task<IActionResult> Listar(
            [FromBody] ObtenerVentasParams parametros
        )
        {
            var data = await _mediator.Send(new ObtenerVentasQuery(parametros));

            if (data == null || data.Items.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No existe data")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

    }
}
