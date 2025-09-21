using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries
{
    public class EntidadFinancieraQuery : IEntidadFinancieraQuery
    {
        private readonly IDapperQueryService _dapperService;

        public EntidadFinancieraQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<EntidadeFinancieraTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };

            var response = await _dapperService.QueryAsync<EntidadeFinancieraTodosModel>("uspGetEntidadesFinancieras", parameters);

            return response.ToList();
        }

        public async Task<EntidadeFinancieraTodosModel> ObtenerEntidadFinancieraPorIdAsync(int IdEntidad)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdEntidad = IdEntidad
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<EntidadeFinancieraTodosModel>("uspGetEntidadesFinancieras", parameters);

            return response;
        }
    }
}
