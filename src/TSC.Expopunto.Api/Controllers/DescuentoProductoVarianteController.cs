using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries.Models;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/descuento-producto-variante")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DescuentoProductoVarianteController : Controller
    {
        private readonly IDescuentoProductoVarianteCommand _command;
        private readonly IDescuentoProductoVarianteQuery _query;

        public DescuentoProductoVarianteController(IDescuentoProductoVarianteCommand command, IDescuentoProductoVarianteQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> Listar([FromBody] DescuentoProductoVarianteListaParametros parametros)
        {
            parametros.OrdenarPor = string.IsNullOrEmpty(parametros.OrdenarPor)
                ? "IdDescuento"
                : parametros.OrdenarPor;

            parametros.OrdenDireccion = parametros.OrdenDireccion?.ToUpper() == "DESC" ? "DESC" : "ASC";

            var data = await _query.ListarAsync(parametros);

            if (data == null || data.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe data"));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpGet("listar-combo")]
        public async Task<IActionResult> ListarCombo()
        {
            var data = await _query.ListarComboAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe registros"));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpGet("listar-por-id")]
        public async Task<IActionResult> ListarPorId([FromQuery] int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id enviado no es válido"));
            }

            var data = await _query.ListarPorIdAsync(id);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Registro no encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] DescuentoProductoVarianteModel model)
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _command.ProcesarAsync(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] DescuentoProductoVarianteModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El Id no es válido"));
            }

            model.Opcion = (int)OperationType.Delete;
            var data = await _command.ProcesarAsync(model);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso"));
        }

    }
}
