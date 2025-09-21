using TSC.Expopunto.Domain.Models;

using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries
{
    public class PersonaQuery : IPersonaQuery
    {
        private readonly IDapperQueryService _dapperService;

        public PersonaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<PersonaTodosModel>> ListarPersonasAsync(PersonasListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdPersona = 0,
                pFiltroNombre = parametro.Nombre,
                pFiltroCodTipoPersona = parametro.CodTipoPersona, //  Nuevo filtro
                pFiltroIdTipoDocumento = parametro.IdTipoDocumento, // Nuevo filtro
                pFiltroNumeroDocumento = parametro.NumeroDocumento, //  Nuevo filtro
                pFiltroActivo = true,//parametro.Activo
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                pOrdenPor= parametro.OrdenarPor,
                pOrdenDireccion = parametro.OrdenDireccion
            };

            var response = await _dapperService.QueryAsync<PersonaTodosModel>("uspGetPersonas", parameters);
            return response.ToList();
        }

        public async Task<List<PersonaTodosModel>> ListarPersonasPorEstadoAsync(bool? activo)
        {
            var parameters = new
            {
                pOpcion = 2,
                pFiltroActivo = activo
            };

            var response = await _dapperService.QueryAsync<PersonaTodosModel>("uspGetPersonas", parameters);
            return response.ToList();
        }

        public async Task<List<PersonaTodosModel>> ListarComboPersonasAsync()
        {
            var parameters = new
            {
                pOpcion = 2, // mismo que listar activos
                pFiltroActivo = true
            };

            var response = await _dapperService.QueryAsync<PersonaTodosModel>("uspGetPersonas", parameters);
            return response.ToList();
        }

        public async Task<PersonaTodosModel?> ListarPersonasPorIdAsync(int idPersona)
        {
            var parameters = new
            {
                pOpcion = 3,
                pIdPersona = idPersona
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<PersonaTodosModel>("uspGetPersonas", parameters);
            return response;
        }
    }
}
