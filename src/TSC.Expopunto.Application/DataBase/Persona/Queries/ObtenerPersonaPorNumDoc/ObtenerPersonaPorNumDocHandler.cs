using MediatR;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DTOs.ApiRestPeru;
using TSC.Expopunto.Application.External.ApiRestPeru;
using TSC.Expopunto.Application.Interfaces.Repositories.Persona;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Persona;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.ObtenerPersonaPorNumDoc
{
    public class ObtenerPersonaPorNumDocHandler : IRequestHandler<ObtenerPersonaPorNumDocQuery, PagedResult<PersonaTodosModel>>
    {
        private readonly IPersonaRepository _repository;
        private readonly IApiRestPeruService _apiRestPeruService;

        public ObtenerPersonaPorNumDocHandler(IPersonaRepository repository, IApiRestPeruService apiRestPeruService)
        {
            this._repository = repository;
            this._apiRestPeruService = apiRestPeruService;
        }

        public async Task<PagedResult<PersonaTodosModel>> Handle(ObtenerPersonaPorNumDocQuery request, CancellationToken cancellationToken)
        {
            int idTipoDocumento = 0;
            string numeroDocumento = "";
            PagedResult<PersonaTodosModel> resultadoBusqueda = new PagedResult<PersonaTodosModel>();
            var filtro = request.parametro.FiltroModalBusqueda?.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
                return resultadoBusqueda;

            resultadoBusqueda = await _repository.ListarPersonasModalBusquedaAsync(request.parametro);

            if (resultadoBusqueda != null && resultadoBusqueda.Data.Count > 0)
            {
                return resultadoBusqueda;
            }

            PersonaDto? personaExterna = null;

            bool esNumero = filtro.All(char.IsDigit);

            if (esNumero)
            {
                if (filtro.Length == 8)
                {
                    // DNI
                    personaExterna = await _apiRestPeruService.ObtenerPersonaPorDniAsync(filtro);
                    idTipoDocumento = 1;
                    if (personaExterna != null)
                    {
                        numeroDocumento = personaExterna.Dni;
                    }
                }
                else if (filtro.Length == 11)
                {
                    // RUC
                    personaExterna = await _apiRestPeruService.ObtenerDatosEmpresaPorDniAsync(filtro);
                    idTipoDocumento = 3;
                    if (personaExterna != null)
                    {
                        numeroDocumento = personaExterna.Ruc;
                    }
                }
            }

            if (personaExterna == null)
            {
                return new PagedResult<PersonaTodosModel>()
                {
                    Total = 0,
                    Data = new List<PersonaTodosModel>(),
                    FilasPorPagina = request.parametro.FilasPorPagina,
                    Pagina = request.parametro.Pagina,
                    TotalPaginas = 0
                };
            }

            await _repository.ProcesarAsync(new PersonaEntity()
            {
                Opcion = (int)OperationType.Create,
                Id = 0,
                CodTipoPersona = "C",
                IdTipoDocumento = idTipoDocumento,
                NumeroDocumento = numeroDocumento,
                RazonSocial = personaExterna.NombreCompleto,
                Nombres = personaExterna.Prenombres,
                Apellidos = personaExterna.ApellidoPaterno + " " + personaExterna.ApellidoMaterno,
                Direccion = personaExterna.Direccion,
                Celular = "",
                IdUsuario = request.parametro.IdUsuario,
                Activo = true,
                DetalleMotivoBaja = ""
            });

            resultadoBusqueda = await _repository.ListarPersonasModalBusquedaAsync(request.parametro);

            return resultadoBusqueda;
        }
    }
}
