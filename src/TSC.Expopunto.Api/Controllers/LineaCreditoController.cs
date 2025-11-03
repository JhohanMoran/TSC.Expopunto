using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.LineaCredito.Commands;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Controllers
{
    [Authorize]
    [Route("api/v1/linea-credito")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class LineaCreditoController : ControllerBase
    {
        private readonly ILineaCreditoCommand _lineaCreditoCommand;
        private readonly ILineaCreditoQuery _lineaCreditoQuery;
        public LineaCreditoController(ILineaCreditoCommand lineaCreditoCommand, ILineaCreditoQuery lineaCreditoQuery)
        {
            _lineaCreditoCommand = lineaCreditoCommand;
            _lineaCreditoQuery = lineaCreditoQuery;
        }
        [HttpGet("listar")]
        public async Task<IActionResult> ListarLineasCredito([FromQuery] LineaCreditoParam param)
        {
            var data = await _lineaCreditoQuery.ListarLineasCreditoAsync(param);
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe lineas de credito")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("obtener-por-id/{id:int}")]
        public async Task<IActionResult> ObtenerLineaCreditoPorId([FromRoute] int id)
        {
            var data = await _lineaCreditoQuery.ObtenerLineaCreditoPorIdAsync(id);
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe linea de credito")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("obtener-por-id-persona/{idPersona:int}")]
        public async Task<IActionResult> ObtenerLineaCreditoPorIdPersona([FromRoute] int idPersona)
        {
            var data = await _lineaCreditoQuery.ObtenerLineaCreditoPorIdPersonaAsync(idPersona);
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe linea de credito")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        /// <summary>
        /// Sincroniza los datos de personas y líneas de crédito en la base de datos.
        /// </summary>
        /// <remarks>
        /// Este proceso toma como base la información proveniente de planilla y los parámetros
        /// configurados para calcular el porcentaje de la línea de crédito correspondiente 
        /// a cada trabajador. Posteriormente, actualiza las tablas relacionadas a personas 
        /// y líneas de crédito en la base de datos.
        /// </remarks>
        /// <param name="model">
        /// Objeto de tipo <see cref="LineaCreditoModel"/> que contiene los datos a procesar.
        /// El campo <c>Opcion</c> se establece automáticamente en 1 para indicar que 
        /// la operación es de sincronización.
        /// </param>
        /// <returns>
        /// Retorna un <see cref="IActionResult"/> con código de estado 200 (OK) y un mensaje 
        /// de éxito si la sincronización se realiza correctamente.
        /// </returns>
        [HttpPost("sincronizar-data")]
        public async Task<IActionResult> SincronizarData([FromBody] LineaCreditoModel model)
        {
            model.Opcion = 1; // Opcion 1 para sincronizar data
            await _lineaCreditoCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, message: "Exitoso")
            );
        }

        [HttpPost("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] LineaCreditoModel model)
        {
            model.Opcion = (int)OperationType.Update;
            await _lineaCreditoCommand.ProcesarAsync(model);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, message: "Exitoso")
            );
        }
    }
}
