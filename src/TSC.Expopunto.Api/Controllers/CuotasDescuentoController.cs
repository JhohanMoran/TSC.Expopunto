using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries;
using TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common.ModelExcel;

namespace TSC.Expopunto.Api.Controllers
{
    [Authorize]
    [Route("api/v1/cuotas-descuento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CuotasDescuentoController : ControllerBase
    {
        private readonly ICuotasDescuentoQuery _cuotasDescuentoQuery;
        private readonly IModelExcelRepository _modelExcelRepository;
        public CuotasDescuentoController(ICuotasDescuentoQuery cuotasDescuentoQuery, 
            IModelExcelRepository modelExcelRepository)
        {
            _cuotasDescuentoQuery = cuotasDescuentoQuery;
            _modelExcelRepository = modelExcelRepository;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos([FromQuery]CuotasDescuentoParam param)
        {
            var data = await _cuotasDescuentoQuery.ListarTodosAsync(param);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
            );
        }

        [HttpGet("exportar")]
        public FileResult ExportarExcel([FromQuery] CuotasDescuentoParam param)
        {
            var data = _cuotasDescuentoQuery.ListarExcel(param);
            var stream = _modelExcelRepository.ExportExcelDefault(data, "Cuotas Planilla", sticky: true);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuotas_Planilla.xlsx");
        }

        [HttpGet("exportar-sofya")]
        public FileResult ExportarSofyaExcel([FromQuery] CuotasDescuentoParam param)
        {
            var data = _cuotasDescuentoQuery.ListarSofyaExcel(param);
            var stream = _modelExcelRepository.ExportExcelDefault(data, "Cuotas Sofya", showHeaders: false);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuotas_Sofya.xlsx");
        }
    }
}
