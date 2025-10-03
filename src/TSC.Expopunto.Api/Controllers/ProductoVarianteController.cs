using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Queries;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/producto-variante")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProductoVarianteController : ControllerBase
    {
        private readonly IProductoVarianteQuery _productoVarianteQuery;

        public ProductoVarianteController(IProductoVarianteQuery productoVarianteQuery)
        {
            _productoVarianteQuery = productoVarianteQuery;
        }

        [HttpPost("listar-todos-por-paginacion")]
        public async Task<IActionResult> ListarProductosVarianteTodosAsync([FromBody] ProductosVarianteParametros parametro)
        {
            var response = await _productoVarianteQuery.ListarProductosVarianteTodosAsync(parametro);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
            );
        }

    }
}
