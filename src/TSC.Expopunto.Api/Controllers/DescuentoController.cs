using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Descuento.Commands;
using TSC.Expopunto.Application.DataBase.Descuento.Queries;
using TSC.Expopunto.Application.DataBase.Descuento.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/descuento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DescuentoController : Controller
    {

        private readonly IDescuentoCommand _descuentoCommand;
        private readonly IDescuentoQuery _descuentoQuery;
        public DescuentoController(IDescuentoCommand descuentoCommand, IDescuentoQuery descuentoQuery)
        {
            _descuentoCommand = descuentoCommand;
            _descuentoQuery = descuentoQuery;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarDescuentos(
            [FromBody] DescuentosListaParametros parametro
        )
        {
            parametro.OrdenarPor = string.IsNullOrEmpty(parametro.OrdenarPor)
             ? "nombre"
             : parametro.OrdenarPor.ToLower();

            parametro.OrdenDireccion = parametro.OrdenDireccion?.ToUpper() == "DESC"
                ? "DESC"
                : "ASC";


            Console.WriteLine($"DEBUG -> Pagina={parametro.Pagina}, Filas={parametro.FilasPorPagina}, OrdenarPor={parametro.OrdenarPor}, OrdenDireccion={parametro.OrdenDireccion}");



            var data = await _descuentoQuery.ListarDescuentosAsync(parametro);


            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe data")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }


        [HttpGet("listar-por-estado")]
        public async Task<IActionResult> ListarDescuentosPorEstado([FromQuery] bool? activo)
        {
            var data = await _descuentoQuery.ListarDescuentosPorEstadoAsync(activo);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe descuento")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-combo")]
        public async Task<IActionResult> ListarComboDescuentos()
        {

            var data = await _descuentoQuery.ListarComboDescuentosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe descuentos")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("listar-por-id")]
        public async Task<IActionResult> ListarDescuentoPorIdAsync([FromQuery] int idDescuento)
        {
            if (idDescuento == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El id enviado no es valido")
                );
            }

            var data = await _descuentoQuery.ListarDescuentosPorIdAsync(idDescuento);

            if (data == null)
            {
                return StatusCode(
                StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Descuento no encontrado")
                );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] DescuentoModel model,
            [FromServices] IValidator<DescuentoModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors)
                );
            }

            model.Opcion = (int)OperationType.Create;
            var data = await _descuentoCommand.ProcesarAsync(model, model.Detalles);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] DescuentoModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
                );
            }

            model.Opcion = (int)OperationType.Update;
            var data = await _descuentoCommand.ProcesarAsync(model, model.Detalles);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] DescuentoModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El idUsuario no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _descuentoCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}

