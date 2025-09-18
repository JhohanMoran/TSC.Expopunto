using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
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
        private readonly IGuiaEntradaCommand _guiaEntradaCommand;
        private readonly IGuiaEntradaQuery _guiaEntradaQuery;

        public GuiaEntradaController(IGuiaEntradaCommand guiaEntradaCommand, IGuiaEntradaQuery guiaEntradaQuery)
        {
            _guiaEntradaCommand = guiaEntradaCommand;
            _guiaEntradaQuery = guiaEntradaQuery;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(
            [FromBody] GuiaEntradaModel model
        )
        {
            model.Opcion = (int)OperationType.Create;

            var data = await _guiaEntradaCommand.ProcesarAsync(model);
            return StatusCode(
                        StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }



        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizarf(
             [FromBody] GuiaEntradaModel model
            )
        {
            model.Opcion = (int)OperationType.Update;

            var data = await _guiaEntradaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }


        [HttpGet("listar")]
        public async Task<IActionResult> ListarGuiaEntrada()
        {
            var data = await _guiaEntradaQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten guias entradas"));
            }


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }


        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerGuiaEntradaPorId(
        [FromQuery] int idGuiaEntrada)
        {
            if (idGuiaEntrada == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de la Guia Entrada no es válido"));
            }
            var data = await _guiaEntradaQuery.ObtenerGuiaEntradaPorIdAsync(idGuiaEntrada);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontró la Guia Entrada"));


            return StatusCode(
            StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")


           );
        }
    }
}
