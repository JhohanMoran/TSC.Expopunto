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
                p_opcion = 1
            };

            var response = await _dapperService.QueryAsync<EntidadeFinancieraTodosModel>(
                "uspGetEntidadesFinancieras", parameters);

            return response.ToList();
        }

        public async Task<EntidadeFinancieraTodosModel> ObtenerEntidadFinancieraPorIdAsync(int idEntidad)
        {
            var parameters = new
            {
                p_opcion = 2,
                p_idEntidad = idEntidad
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<EntidadeFinancieraTodosModel>("uspGetEntidadesFinancieras", parameters);

            return response;
        }
    }
}
