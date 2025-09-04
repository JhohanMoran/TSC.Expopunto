using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.FormaPago.Queries;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/forma-pago")]
    [ApiController]
    public class FormaPagoController : Controller
    {
        private readonly IFormaPagoQuery _formaPagoQuery;

        public FormaPagoController(IFormaPagoQuery formaPagoQuery)
        {
            _formaPagoQuery = formaPagoQuery;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarFormasPago()
        {
            var data = await _formaPagoQuery.ListarTodosAsync();

            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No exiten Formas de Pago"));
            }
            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitosos")
             );
        }

        [HttpGet("obtener-por-id")]
        public async Task<IActionResult> ObtenerFormaPago(
        [FromQuery] int idFormaPago)
        {

            if (idFormaPago == 0)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "El ID de Forma de Pago no es válido"));
            }
            var data = await _formaPagoQuery.ObtenerFormaPagoPorIdAsync(idFormaPago);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontró la forma de pago"));


            return StatusCode(StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")


           );
        }

    }
}
