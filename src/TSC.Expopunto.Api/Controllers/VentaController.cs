using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.Ventas;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Crear;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;
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
            var command = new CrearVentaCommand(
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
                true,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProducto,
                    d.IdTalla,
                    d.Cantidad,
                    d.PrecioUnitario,
                    true
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
            [FromBody] ActualizarVentaRequest request
        )
        {
            var command = new ActualizarVentaCommand(
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
                request.Activo, 
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProducto,
                    d.IdTalla,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Activo
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
        )
        {
            var command = new EliminarVentaCommand(
                OperationType.Delete,
                request.Id,
                request.IdUsuario
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
