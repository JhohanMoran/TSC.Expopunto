using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Producto.Command;
using TSC.Expopunto.Application.DataBase.Producto.Queries;
using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/producto")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoQuery _productoQuery;
        private readonly IProductoCommand _productoCommand;

        public ProductoController(IProductoQuery productoQuery, IProductoCommand productoCommand)
        {
            _productoQuery = productoQuery;
            _productoCommand = productoCommand;
        }
        [HttpGet("listar-paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] ProductoParams param)
        {
            var response = await _productoQuery.ListarPaginadoAsync(param);

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-activos")]
        public async Task<IActionResult> ListarActivos()
        {
            var response = await _productoQuery.ListarActivosAsync();

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-por-id")]
        public async Task<IActionResult> ListarPorId([FromBody] int id)
        {
            if (id == null || id == 0)
            {
                return StatusCode(
                   StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id es necesario")
                );
            }

            var response = await _productoQuery.ListarPorIdAsync(id);

            if (response == null)
            {

                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, response, "No ha sido encontrado un registro")
                 );
            }

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }


        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoModel model
        )
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _productoCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }
        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ProductoModel model)
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _productoCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] ProductoModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El id del producto no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _productoCommand.ProcesarAsync(model);


            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }
        [HttpGet("listar-prod-variantes")]
        public async Task<IActionResult> ListarProdVariantes([FromQuery] ProductoParams param)
        {
            var response = await _productoQuery.ListarProdVariantesAsync(param);

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }
        [HttpGet("listar-tallas")]
        public async Task<IActionResult> ListarTallas()
        {
            var response = await _productoQuery.ListarTallasAsync();

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }
        [HttpGet("listar-colores")]
        public async Task<IActionResult> ListarColores()
        {
            var response = await _productoQuery.ListarColoresAsync();

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }
        [HttpPost("crear-variante")]
        public async Task<IActionResult> CrearVariante([FromBody] ProductoModel model
        )
        {
            model.Opcion = 4;
            var data = await _productoCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }
        [HttpPost("actualizar-variante")]
        public async Task<IActionResult> ActualizarVariante([FromBody] ProductoModel model)
        {
            model.Opcion = 5;
            var data = await _productoCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("eliminar-variante")]
        public async Task<IActionResult> EliminarVariante([FromBody] ProductoModel model)
        {
            if (model.IdProductoVariante == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id del producto no es válido")
                );
            }

            model.Opcion = 6;

            var data = await _productoCommand.ProcesarAsync(model);


            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }
    }
}
