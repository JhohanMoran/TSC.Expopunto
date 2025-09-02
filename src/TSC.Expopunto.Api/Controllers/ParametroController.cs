using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/parametro")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ParametroController : Controller
    {
        private readonly IParametroQuery _parametroQuery;
        public ParametroController(
            IParametroQuery parametroQuery
        )
        {
            _parametroQuery = parametroQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarPerfiles()
        {
            var data = await _parametroQuery.ListarParametrosAsync();

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

    }
}
