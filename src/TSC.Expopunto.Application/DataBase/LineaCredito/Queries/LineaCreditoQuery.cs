using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.LineaCredito.Queries
{
    public class LineaCreditoQuery : ILineaCreditoQuery
    {
        private readonly IDapperQueryService _dapperService;
        public LineaCreditoQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<LineaCreditoTodoModel>> ListarLineasCreditoAsync(LineaCreditoParam param)
        {
            var parameters = new
            {
                pOpcion = 1,
                pId = param.Id,
                pIdPersona = param.IdPersona
            };
            var response = await _dapperService.QueryAsync<LineaCreditoTodoModel>("uspGetLineasCredito", parameters);
            return response.ToList();
        }

        public async Task<LineaCreditoTodoModel> ObtenerLineaCreditoPorIdAsync(int id)
        {
            var parameters = new
            {
                pOpcion = 2,
                pId = id,
                pIdPersona = (int?)null
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<LineaCreditoTodoModel>("uspGetLineasCredito", parameters);
            return response;
        }

        public async Task<LineaCreditoTodoModel> ObtenerLineaCreditoPorIdPersonaAsync(int idPersona)
        {
            var parameters = new
            {
                pOpcion = 3,
                pId = (int?)null,
                pIdPersona = idPersona
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<LineaCreditoTodoModel>("uspGetLineasCredito", parameters);
            return response;
        }
    }
}
