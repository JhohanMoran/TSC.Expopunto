using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Sede.Queries
{
    public class SedeQuery : ISedeQuery
    {
        private readonly IDapperQueryService _dapperService;

        public SedeQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<SedesTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<SedesTodosModel>("uspGetSedes",
            parameters);
            return response.ToList();
        }

        public async Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdSede = idSede
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<SedesTodosModel>("uspGetSedes",
            parameters);
            return response;
        }

    }
}
