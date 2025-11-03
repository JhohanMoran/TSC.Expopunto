using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.SedeCompleta.Commands;
using TSC.Expopunto.Application.DataBase.SedeCompleta.Dto;
using TSC.Expopunto.Application.DataBase.SedeCompleta.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/sede-completa")]
    [ApiController]
    // Elimina el filtro global para este controlador
    // [TypeFilter(typeof(ExceptionManager))]
    public class SedeCompletaController : Controller
    {
        private readonly ISedeCompletaCommand _command;
        private readonly ISedeCompletaQuery _query;

        public SedeCompletaController(ISedeCompletaCommand command, ISedeCompletaQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpGet("reporte")]
        public async Task<IActionResult> Reporte([FromQuery] string? nombre = null)
        {
            var data = await _query.ListarReporteAsync(nombre);
            return Ok(ResponseApiService.Response(200, data, "Exitoso"));
        }

        [HttpPost("obtener")]
        public async Task<IActionResult> Obtener([FromBody] SedeRequestDto request)
        {
            var data = await _query.ObtenerParaEditarAsync(request.Id);
            return Ok(ResponseApiService.Response(200, data, "Exitoso"));
        }


        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] SedeCompletaModel model)
        {
            try
            {
                Console.WriteLine($"Activo recibido: {model.Activo}");
                await _command.ProcesarAsync(model);
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