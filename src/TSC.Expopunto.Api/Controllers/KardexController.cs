using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Kardex.Queries;
using TSC.Expopunto.Application.DataBase.Kardex.Queries.Models;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common.ModelExcel;

namespace TSC.Expopunto.Api.Controllers
{
    //[Authorize]
    [Route("api/v1/kardex")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class KardexController : ControllerBase
    {
        private readonly IKardexQuery _kardexQuery;
        private readonly IModelExcelRepository _modelExcelRepository;
        public KardexController(
            IKardexQuery kardexQuery
            , IModelExcelRepository modelExcelRepository
        )
        {
            _kardexQuery = kardexQuery;
            _modelExcelRepository = modelExcelRepository;
        }
        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos([FromQuery] KardexParam param)
        {
            var data = await _kardexQuery.ListarTodosAsync(param);
            if (data == null || data.Count == 0)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No existe usuarios")
               );
            }
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Exitoso")
                );
        }


        [HttpGet("exportar")]
        public FileResult ExportarExcel([FromQuery] KardexParam param)
        {
            var data = _kardexQuery.ListarExcel(param);
            var stream = _modelExcelRepository.ExportExcelDefault(data, "Control de Stock");
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Control_Stock.xlsx");
        }

    }
}
