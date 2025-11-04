using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
using TSC.Expopunto.Application.DataBase.Sede.DTO;
using TSC.Expopunto.Application.DataBase.Sede.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/sede")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SedeController : Controller
    {
        private readonly ISedeCommand _sedeCommand;
        private readonly ISedeQuery _sedeQuery;

        public SedeController(ISedeCommand sedeCommand, ISedeQuery sedeQuery)
        {
            _sedeCommand = sedeCommand;
            _sedeQuery = sedeQuery;
        }
        
        [HttpGet("listar")]
        public async Task<IActionResult> Listar([FromQuery] string? nombre = null)
        {
            var data = await _sedeQuery.ListarAsync(nombre);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
            );
        }


        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerSedePorId(
        [FromQuery] int idSede)
        {
            if (idSede == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de la sede no es válido"));
            }
            var data = await _sedeQuery.ObtenerSedePorIdAsync(idSede);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            var data = await _sedeQuery.ListarTodosAsync();

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
            );
        }

        [HttpGet("reporte")]
        public async Task<IActionResult> Reporte([FromQuery] string? nombre = null)
        {
            var data = await _sedeQuery.ListarReporteAsync(nombre);
            return Ok(ResponseApiService.Response(200, data, "Exitoso"));
        }

        [HttpPost("obtener")]
        public async Task<IActionResult> Obtener([FromBody] SedeRequestDto request)
        {
            var data = await _sedeQuery.ObtenerParaEditarAsync(request.Id);
            return Ok(ResponseApiService.Response(200, data, "Exitoso"));
        }


        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] SedeCompletaModel model)
        {
            try
            {
                Console.WriteLine($"Activo recibido: {model.Activo}");
                await _sedeCommand.ProcesarAsync(model);
                return Ok(ResponseApiService.Response(200, null, "Guardado exitoso"));
            }
            catch (Exception ex)
            {
                // Devolver el mensaje de error específico del stored procedure
                // El mensaje viene del RAISERROR en el SP
                var mensajeError = ex.Message;

                // Si el mensaje contiene "Error en uspGuardarSedeCompleto:", extraer el mensaje real
                if (mensajeError.Contains("Error en uspGuardarSedeCompleto:"))
                {
                    mensajeError = mensajeError.Replace("Error en uspGuardarSedeCompleto:", "").Trim();
                }

                // Devolver error 400 con el mensaje específico
                return BadRequest(new
                {
                    statusCode = 400,
                    message = mensajeError,
                    success = false
                });
            }
        }


    }
}
