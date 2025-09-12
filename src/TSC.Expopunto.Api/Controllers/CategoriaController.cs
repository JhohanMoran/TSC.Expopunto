using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Categoria.Command;
using TSC.Expopunto.Application.DataBase.Categoria.Queries;
using TSC.Expopunto.Application.DataBase.Producto.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;


namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/categoria")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly ICategoriaCommand _categoriaCommand;

        public CategoriaController(ICategoriaQuery categoriaQuery, ICategoriaCommand categoriaCommand)
        {
            _categoriaCommand = categoriaCommand;
            _categoriaQuery = categoriaQuery;
        }
        [HttpGet("listar-paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] CategoriaParams param)
        {
            var response = await _categoriaQuery.ListarPaginadoAsync(param);

            if (response.Count() == 0)
            {

                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se ha encontrado registros")
                 );
            }

            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-activos")]
        public async Task<IActionResult> ListarActivos()
        {
            var response = await _categoriaQuery.ListarActivosAsync();

            if (response.Count() == 0)
            {

                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se ha encontrado registros")
                 );
            }

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

            var response = await _categoriaQuery.ListarPorIdAsync(id);

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
        public async Task<IActionResult> Crear([FromBody] CategoriaModel model
        )
        {
            model.Opcion = (int)OperationType.Create;
            var data = await _categoriaCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Exitoso"));
        }
        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] CategoriaModel model)
        {
            model.Opcion = (int)OperationType.Update;
            var data = await _categoriaCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );

        }
        [HttpPost("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] CategoriaModel model)
        {
            if (model.Id == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status200OK, null, "El id de la Entidad no es válido")
                );
            }

            model.Opcion = (int)OperationType.Delete;

            var data = await _categoriaCommand.ProcesarAsync(model);


            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );

        }
    }
}

