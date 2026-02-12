using MediatR;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Api.Models.DocumentoEstado;
using TSC.Expopunto.Api.Models.Ventas;
// Este conecta con los modelos de Request (FiltroVentaDepositoRequest y RegistrarDepositoRequest)
using TSC.Expopunto.Api.Models.Ventas;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Queries;
using TSC.Expopunto.Application.DataBase.Venta.Commands.AnularVenta;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Aprobar;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Crear;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;
using TSC.Expopunto.Application.DataBase.Venta.Commands.RegistrarDeposito;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaAprobacion;
// Estos conectan con las Queries y Commands que creaste en la carpeta Venta
using TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaDeposito;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorSerieNumero;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentasPorIdPersona;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Application.Features.Documentos.Queries;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Common;
using TSC.Expopunto.Common.ModelExcel;


namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/venta")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VentaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVentaRepository _repository; // Cambia el nombre si usas uno distinto como _ventaRepository
        private readonly IModelExcelRepository _modelExcelRepository;


        public VentaController(IVentaRepository repository,IModelExcelRepository modelExcelRepository,IMediator mediator)
        {
            _repository = repository;
            _modelExcelRepository = modelExcelRepository;
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
                request.TipoVenta,
                request.IdTipoComprobante,
                request.Serie,
                request.Numero,
                request.IdPersona,
                request.IdTipoMoneda,
                request.IdUsuarioVendedor,

                request.Cantidad,
                request.OpGravadas,
                request.OpExoneradas,
                request.OpInafectas,
                request.OpGratuitas,
                request.TotalDescuento,
                request.TotalIGV,
                request.TotalICBPER,
                request.ImporteTotal,
                request.IdUsuario,

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
            var respuesta = await _mediator.Send(new GenerarDocumentoPdfQuery(idVenta));

            return File(respuesta.ArchivoPdf, "application/pdf", $"{respuesta.NombreArchivo}.pdf");
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

        [HttpPost("listar-ventas-para-aprobacion")]
        public async Task<IActionResult> ListarVentasParaAprobacion(
           [FromBody] FiltroVentaAprobacionRequest parametros
        )
        {
            var data = await _mediator.Send(new ListarVentasParaAprobacionQuery(parametros.Fecha));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("aprobar")]
        public async Task<IActionResult> Aprobar([FromBody] VentaAprobacionRequest request)
        {
            if (request.Ids == null || request.Ids.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No hay venta seleccionada para aprobar")
                );
            }

            var data = await _mediator.Send(new AprobarVentaCommand(request.IdUsuario, request.Ids));

            return StatusCode(
              StatusCodes.Status200OK,
              ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
        // 1. Para listar las ventas pendientes de depósito (Usa uspGetDepositos Opcion 1)
        [HttpPost("listar-ventas-para-depositos")]
        public async Task<IActionResult> ListarVentasParaDepositos(
            [FromBody] FiltroVentaDepositoRequest parametros
        )
        {
            // Crearemos esta Query similar a ListarVentasParaAprobacionQuery
            var data = await _mediator.Send(new ListarVentasParaDepositoQuery(parametros.Fecha));

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        // 2. Para registrar el depósito (Usa uspSetDepositos)
        [HttpPost("registrar-deposito")]
        public async Task<IActionResult> RegistrarDeposito([FromBody] RegistrarDepositoRequest request)
        {
            // Validamos que existan ventas seleccionadas
            if (request.IdsVentas == null || request.IdsVentas.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No hay ventas seleccionadas para depositar")
                );
            }

            // Crearemos este Command para manejar la lógica de inserción masiva
            var data = await _mediator.Send(new RegistrarDepositoCommand(
                request.NroOperacion,
                request.Fecha,
                request.IdUsuario,
                request.IdsVentas));

            return StatusCode(
              StatusCodes.Status200OK,
              ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }
        [HttpGet("exportar-excel-depositos")]
        public async Task<IActionResult> ExportarExcel([FromQuery] DateTime fecha)
        {
            // 1. Obtenemos los datos originales del repositorio
            var data = await _repository.ListarVentasParaDepositoAsync(fecha);

            // 2. Creamos una nueva lista con el orden de columnas solicitado
            // El orden en que escribas estas propiedades será el orden en el Excel
            var dataFormateada = data.Select(v => new {
                Estado = v.NombreEstado,
                NroOperacion = v.NroOperacion,
                Usuario_Registro = v.NombreCompletoUsuario,
                Fecha_Registro= v.FechaRegistroDisplay,
                Documento = $"{v.Serie}-{v.Numero}",
                Cliente = v.NombrePersona,
                Total = v.ImporteTotal
            }).ToList();

            // 3. Generamos el Excel con la data reordenada
            var stream = _modelExcelRepository.ExportExcelDefault(dataFormateada, "Reporte de Depósitos");

            return File(
                stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Reporte_Depositos_{fecha:ddMMyyyy}.xlsx"
            );
        }
    }
}
