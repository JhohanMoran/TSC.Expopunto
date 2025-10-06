using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.Ventas;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Queries;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Crear;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentasPorIdPersona;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Application.Features.Documentos.Queries;
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
                request.Hora,
                request.IdSede,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersona,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,
                request.IdUsuario,
                true,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProductoVariante,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.IdDescuento,
                    true
                )).ToList(),
                request.FormasPago.Select(d => new VentaFormaPagoCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdFormaPago,
                    d.DescripcionFormaPago,
                    d.Monto,
                    d.ReferenciaPago
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
                request.Hora,
                request.IdSede,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersona,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,
                request.IdUsuario,
                request.Activo,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProductoVariante,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.IdDescuento,
                    d.Activo
                )).ToList(),
                request.FormasPago.Select(d => new VentaFormaPagoCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdFormaPago,
                    d.DescripcionFormaPago,
                    d.Monto,
                    d.ReferenciaPago
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

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-por-id-persona/{idPersona:int}")]
        public async Task<IActionResult> ListarPorPersona(
            [FromRoute] int idPersona
        )
        {
            var data = await _mediator.Send(new ObtenerVentasPorIdPersonaQuery(idPersona));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-detalle-por-id-venta/{idVenta:int}")]
        public async Task<IActionResult> ListarDetalleVentaPorIdVenta(
            [FromRoute] int idVenta
        )
        {
            var data = await _mediator.Send(new ObtenerDetalleVentaPorIdVentaQuery(idVenta));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-ventas-formas-pago-por-id-venta/{idVenta:int}")]
        public async Task<IActionResult> ListarVentasFormasPagoPorIdVenta(
            [FromRoute] int idVenta
        )
        {
            var data = await _mediator.Send(new ObtenerVentasFormaPagoPorIdVentaQuery(idVenta));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("generar-documento-pdf/{idVenta:int}")]
        public async Task<IActionResult> GetBoletaPdf(int idVenta)
        {
            var pdfBytes = await _mediator.Send(new GenerarDocumentoPdfQuery(idVenta));

            return File(pdfBytes, "application/pdf", $"documento-{idVenta.ToString()}.pdf");
        }

    }
}
