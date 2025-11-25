using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.Persona.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.Interfaces.Repositories.Persona;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Persona;
using TSC.Expopunto.Persistence.DataBase;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;
        public PersonaRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }

        public async Task<PagedResult<PersonaTodosModel>> ListarPersonasModalBusquedaAsync(PersonasListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 5,
                pFiltroModalBusqueda = parametro.FiltroModalBusqueda,
                pTipoBusquedaPersonal = parametro.TipoBusquedaPersonal,
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                pOrdenPor = parametro.OrdenarPor,
                pOrdenDireccion = parametro.OrdenDireccion
            };

            var response = await _dapperQueryService.QueryAsync<PersonaTodosModel>("uspGetPersonas", parameters);

            var responseList = response.ToList();
            var totalRegistros = responseList.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<PersonaTodosModel>
            {
                Data = responseList,
                Total = totalRegistros,
                Pagina = parametro.Pagina,
                FilasPorPagina = parametro.FilasPorPagina
            };
        }

        public async Task<PersonaEntity> ProcesarAsync(PersonaEntity model)
        {
            var response = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetPersona",
                new
                {
                    pOpcion = model.Opcion,
                    pId = model.Id,
                    pCodTipoPersona = model.CodTipoPersona,
                    pIdTipoDocumento = model.IdTipoDocumento,
                    pNumeroDocumento = model.NumeroDocumento,
                    pRazonSocial = model.RazonSocial,
                    pNombres = model.Nombres,
                    pApellidos = model.Apellidos,
                    pDireccion = model.Direccion,
                    pCelular = model.Celular,
                    pIdUsuario = model.IdUsuario,
                    pActivo = model.Activo,
                    pDetalleMotivoBaja = model.DetalleMotivoBaja
                }
            );

            if (response > 0)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
