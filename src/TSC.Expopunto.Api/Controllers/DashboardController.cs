using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Dashboard.Queries;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Api.Controllers
{
    //[Authorize]
    [Route("api/v1/dashboard")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardQuery _dashboardQuery;
        public DashboardController(
            IDashboardQuery dashboardQuery
        )
        {
            _dashboardQuery = dashboardQuery;
        }

        [HttpGet("valores")]
        public async Task<IActionResult> ObtenerValoresDashboard()
        {
            var data = await _dashboardQuery.ObtenerValoresDashboardAsync();//mapeo a este method vinculado al archivo IDashboardQuery
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existen datos para el dashboard")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }

        [HttpGet("charts")]
        public async Task<IActionResult> ObtenerChartsDashboard()
        {
            var data = await _dashboardQuery.ObtenerCartsDashboardAsync();
            if (data == null)
            {
                return StatusCode(
                   StatusCodes.Status404NotFound,
                   ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existen datos para el dashboard")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }
    }
}
