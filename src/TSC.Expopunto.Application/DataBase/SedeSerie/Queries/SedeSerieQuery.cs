using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Application.DataBase.SedeSerie.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Queries
{
    public class SedeSerieQuery : ISedeSerieQuery
    {
        private readonly IDapperQueryService _dapperService;

        public SedeSerieQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<SedeSerieTodosModel>> ListarAsync(int? idSede = null)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdSede = idSede
            };

            var result = await _dapperService.QueryAsync<SedeSerieTodosModel>("uspGetSedeSerie", parameters);
            return result.ToList();
        }

        public async Task<SedeSerieTodosModel> ObtenerPorIdAsync(int id)
        {
            var parameters = new
            {
                pOpcion = 2,
                pId = id
            };

            return await _dapperService.QueryFirstOrDefaultAsync<SedeSerieTodosModel>("uspGetSedeSerie", parameters);
        }

        public async Task<List<SedeSerieTodosModel>> ListarTodosAsync()
        {
            var parameters = new { pOpcion = 3 };
            var result = await _dapperService.QueryAsync<SedeSerieTodosModel>("uspGetSedeSerie", parameters);
            return result.ToList();
        }

        public async Task<List<SedeSerieTodosModel>> ListarSeriesPorSedeTipoComprobanteAsync(int idSede, int idTipoComprobante)
        {
            var parameters = new
            {
                pOpcion = 4,
                pIdSede = idSede,
                pIdTipoComprobante = idTipoComprobante
            };
            var response = await _dapperService.QueryAsync<SedeSerieTodosModel>("uspGetSedeSerie", parameters);
            return response.ToList();
        }

    }
}
