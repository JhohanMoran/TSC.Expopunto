using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Accesos.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/accesos")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class AccesosController : Controller
    {
        private readonly IAccesosQuery _accesosQuery;
        public AccesosController(IAccesosQuery accesosQuery)
        {
            _accesosQuery = accesosQuery;
        }

        [HttpGet("obtener-menu-por-perfil")]
        public async Task<IActionResult> ObtenerUsuarioPorId(
            [FromQuery] int idPerfil
        )
        {
            if (idPerfil == 0)
            {
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de perfil no es válido")
                );
            }

            var data = await _accesosQuery.ObtenerMenuPorPerfilAsync(idPerfil);

            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Acceso no encontrado")
               );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}
