using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Prendas.Queries;
using TSC.Expopunto.Application.DataBase.Prendas.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/producto")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PrendasController : ControllerBase
    {
        private readonly IPrendasQuery _prendasQuery;

        public PrendasController(IPrendasQuery prendasQuery)
        {
            _prendasQuery = prendasQuery;
        }

        [HttpGet("listar-paginado-stock-apt")]
        public async Task<IActionResult> ListarPaginadoStockApt([FromQuery] PrendasParams param)
        {
            var response = await _prendasQuery.ListarPaginadoStockAptAsync(param);

            if (response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status204NoContent,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se encontraron registros.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

    }
}
