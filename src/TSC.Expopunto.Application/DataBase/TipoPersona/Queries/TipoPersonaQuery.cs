using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.TipoPersona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoPersona.Queries
{
    public class TipoPersonaQuery : ITipoPersonaQuery
    {
        private readonly IDapperQueryService _dapperService;

        public TipoPersonaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<TipoPersonaTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };

            var response = await _dapperService.QueryAsync<TipoPersonaTodosModel>("uspGetTiposPersona", parameters);

            return response.ToList();
        }

        public async Task<TipoPersonaTodosModel> ObtenerTipoPersonaPorCodigoAsync(string codigo)
        {
            var parameters = new
            {
                pOpcion = 2,
                pCodigo = codigo
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<TipoPersonaTodosModel>("uspGetTiposPersona", parameters);

            return response;
        }
    }
}
