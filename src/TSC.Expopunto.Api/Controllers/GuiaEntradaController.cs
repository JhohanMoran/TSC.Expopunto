using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.GuiasEntrada;

using TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerDetallesGuiaEntradaPorIdGuia;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Application.Features.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie;
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
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.IdUsuario,
                request.TotalCantidad,
                request.TotalCosto,

                request.Detalles.Select(d => new DetalleGuiaEntradaCommand(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.IdTalla,
                    d.Talla,
                    d.Cantidad,
                    d.NumCaja,
                    d.Nombre,
                    d.CodigoEstilo,
                    d.CodigoPedido,
                    d.Categoria,
                    d.Genero,
                    d.Color,
                    d.CodigoSku,
                    d.IdUsuario
                

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
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.TotalCantidad,
                request.TotalCosto,
                request.IdUsuario,
                request.Detalles.Select(d => new DetalleGuiaEntradaCommand(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.IdTalla,
                    d.Talla,
                    d.Cantidad,
                    d.NumCaja,
                    d.Nombre,
                    d.CodigoEstilo,
                    d.CodigoPedido,
                    d.Categoria,
                    d.Genero,
                    d.Color,
                    d.CodigoSku,
                    d.IdUsuario
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

            if (data == null || data.Data == null || data.Data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, null, "No se encontraron resultados")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

        [HttpGet("listar-por-numero-serie")]
        public async Task<IActionResult> ListarPorNumeroSerie(
            [FromQuery] ObtenerGuiasEntradaParams parametros
        )
        {
            var data = await _mediator.Send(new ObtenerGuiaEntradaPorNumeroSerieQuery(parametros.Opcion, parametros.Numero, parametros.Serie));

            if (data == null)
            {
                return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Guia no encontrada")
                    );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

        [HttpPost("listar-por-numero-serie-pdf")]
        public async Task<IActionResult> ListarPorNumeroSeriePdf(
           [FromBody] ObtenerGuiasEntradaParams parametros
       )
        {
            var data = await _mediator.Send(new ObtenerGuiaEntradaPorNumeroSerieQueryPdf(parametros.Opcion, parametros.Numero, parametros.Serie));

            if (data == null)
            {
                return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Guia no encontrada")
                    );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

        [HttpGet("listar-detalles-por-id-guia")]
        public async Task<IActionResult> ListarPorIdGuia(
            [FromQuery] int idGuia
        )
        {
            var data = await _mediator.Send(new ObtenerDetallesGuiaEntradaPorIdGuiaQuery(idGuia));

            if (data == null)
            {
                return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Guia no encontrada")
                    );
            }
            else if (data.Count() == 0)
            {
                return StatusCode(
                        StatusCodes.Status204NoContent,
                        ResponseApiService.Response(StatusCodes.Status204NoContent, null, "No se encontraron detalles")
                    );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] ActualizarGuiaEntradaCommand param)
        {
            var data = await this._mediator.Send(new EliminarGuiaEntradaCommand(param.Id));

            return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("eliminar-detalle")]
        public async Task<IActionResult> EliminarDetalle([FromBody] DetalleGuiaEntradaRequest param)
        {
            var data = await this._mediator.Send(new EliminarDetalleGuiaEntradaCommand(param.Id, param.IdUsuario));

            return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}

