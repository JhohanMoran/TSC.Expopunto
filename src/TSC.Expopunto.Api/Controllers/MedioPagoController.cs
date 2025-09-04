using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.MedioPago.Queries;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{

    [Route("api/v1/medio-pago")]
    [ApiController]
    public class MedioPagoController : Controller
    {

        private readonly IMedioPagoQuery _medioPagoQuery;

        public MedioPagoController(IMedioPagoQuery medioPagoQuery)
        {
            _medioPagoQuery = medioPagoQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarMediosPago()
        {
            var data = await _medioPagoQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten Medios de Pago"));
            }
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerMedioPago(
        [FromQuery] int idMedioPago)
        {

            if (idMedioPago == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de Medio de Pago no es válido"));
            }
            var data = await _medioPagoQuery.ObtenerMedioPagoPorIdAsync(idMedioPago);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró el medio de pago"));


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")


           );
        }

    }
}
