using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries
{
    public class PersonaQuery:IPersonaQuery
    {
        private readonly IDapperQueryService _dapperService;

        public PersonaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<PersonaTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };

            var response = await _dapperService.QueryAsync<PersonaTodosModel>("uspGetPersonas", parameters);

            return response.ToList();
        }

        public async Task<PersonaTodosModel> ObtenerPersonaPorIdAsync(int IdPersona)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdPersona = IdPersona
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<PersonaTodosModel>("uspGetPersonas", parameters);

            return response;
        }
    }
}
