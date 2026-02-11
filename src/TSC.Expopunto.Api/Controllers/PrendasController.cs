using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Prendas.Queries;
using TSC.Expopunto.Application.DataBase.Prendas.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    [Route("api/v1/prendas")]
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

            if (response == null || response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, null, "No se encontraron prendas en stock.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-clientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var response = await _prendasQuery.ListarClientesAsync();

            if (response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se encontraron clientes.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-pedidos")]
        public async Task<IActionResult> ListarPedidos([FromQuery] string codigoCliente)
        {
            var response = await _prendasQuery.ListarPedidosAsync(codigoCliente);

            if (response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se encontraron pedidos.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-estilos-clientes")]
        public async Task<IActionResult> ListarEstilosClientes([FromQuery] string pedido, string codigoCliente)
        {
            var response = await _prendasQuery.ListarEstilosClientesAsync(pedido, codigoCliente);

            if (response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se encontraron estilos clientes.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }

        [HttpGet("listar-presentaciones")]
        public async Task<IActionResult> ListarPrensentaciones([FromQuery] string pedido)
        {
            var response = await _prendasQuery.ListarPrensentacionesAsync(pedido);

            if (response.Count == 0)
            {
                return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status204NoContent, response, "No se encontraron presentaciones.")
                );
            }
            return StatusCode(
                   StatusCodes.Status200OK,
                   ResponseApiService.Response(StatusCodes.Status200OK, response, "Exitoso")
                );
        }
    }
}
