
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Parametro.Commands;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

using Microsoft.AspNetCore.Authorization;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    //[Authorize]
    [Route("api/v1/parametro")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ParametroController : Controller
    {
        private readonly IParametroCommand _parametroCommand;
        private readonly IParametroQuery _parametroQuery;

        public ParametroController(IParametroCommand parametroCommand, IParametroQuery parametroQuery)
        {
            _parametroCommand = parametroCommand;
            _parametroQuery = parametroQuery;
        }
        [HttpPost("listar")]
        /// <summary>
        /// Lista los parámetros existentes con paginación desde la base de datos.
        /// </summary>
        public async Task<IActionResult> ListarParametros([FromBody] ParametrosListaParametros parametro)
        {
            if (parametro.Pagina <= 0 || parametro.FilasPorPagina <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Parámetros de paginación inválidos")
                );
            }

            var data = await _parametroQuery.ListarParametrosAsync(parametro);

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status204NoContent, data, "No existen parámetros")
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        /// <summary>
        /// Actualiza un parámetro existente en la base de datos.
        /// </summary>
        public async Task<IActionResult> Actualizar([FromBody] ParametroModel model)
        {
            if (model.Id <= 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El id del parámetro no es válido")
                );
            }

            // Forzamos la opción de actualización
            model.Opcion = 2;

            var data = await _parametroCommand.ProcesarAsync(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

    }
}

