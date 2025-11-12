using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.DocumentoEstado;
using TSC.Expopunto.Api.Models.Ventas;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Queries;
using TSC.Expopunto.Application.DataBase.Venta.Commands.AnularVenta;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Crear;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorSerieNumero;
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

        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar(
            [FromBody] GuardarVentaRequest request
        )
        {
            var command = new GuardarVentaCommand(
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
                request.DescuentoTotal,
                request.SubTotal,
                request.Impuesto,
                request.Total,
                request.IdUsuario,
                true,
                request.Detalles.Select(d => new DetalleVentaCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdProductoVariante,
                    d.IdTipoOperacion,
                    d.CodigoTipoOperacion,
                    d.Descripcion,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.AplicaICBP,
                    d.IdDescuento,
                    d.ValorDescuento,
                    d.SubTotal,
                    true
                )).ToList(),
                request.FormasPago.Select(d => new VentaFormaPagoCommand(
                    d.Id,
                    d.IdVenta,
                    d.IdFormaPago,
                    d.Monto,
                    d.ReferenciaPago,
                    d.RutaIcono,
                    d.Activo
                )).ToList()
            );

            var data = await _mediator.Send(command);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
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

        [HttpPost("obtener-venta-por-serie-numero")]
        public async Task<IActionResult> ObtenerVentaPorSerieNumero(
           [FromBody] VentaPorSerieNumeroRequest parametros
        )
        {
            var data = await _mediator.Send(new ObtenerVentaPorSerieNumeroQuery(parametros.Serie, parametros.Numero));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("anular")]
        public async Task<IActionResult> Anular(
            [FromBody] AnularVentaRequest request
        )
        {
            var command = new AnularVentaCommand(
                request.IdVenta,
                request.IdMotivoBaja,
                request.Observacion,
                request.IdUsuario
            );

            var data = await _mediator.Send(command);

            if (data == null)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se pudo realizar la anulación de la venta")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

    }
}
