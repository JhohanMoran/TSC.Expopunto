using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.PersonaDescuento;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class PersonaDescuentoRepository : IPersonaDescuentoRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;
        public PersonaDescuentoRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }
        public async Task<List<PersonaDescuentoDTO>> ListarDescuentosPorIdPersonaAsync(int idPersona)
        {
            try
            {
                var parameters = new
                {
                    Opcion = 1,
                    IdPersona = idPersona
                };

                var response =
                    await _dapperQueryService
                        .QueryAsync<PersonaDescuentoDTO>("uspGetPersonaDescuento", parameters);

                return response.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PersonaDescuentoDTO> ObtenerPersonaDescuentoPorIdAsync(int id)
        {
            var parameters = new
            {
                Opcion = 2,
                Id = id
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<PersonaDescuentoDTO>("uspGetPersonaDescuento", parameters);

            return response;
        }

        public async Task<PersonaDescuentoEntity> ProcesarAsync(PersonaDescuentoEntity parametros)
        {
            var parameters = new
            {
                Opcion = parametros.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create,
                Id = parametros.Id,
                IdPersona = parametros.IdPersona,
                FechaInicio = parametros.FechaInicio,
                FechaFin = parametros.FechaFin,
                ValorDescuento = parametros.ValorDescuento,
                IdUsuario = parametros.IdUsuario,
                Activo = parametros.Activo

            };
            var id = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetPersonaDescuento",
                parameters
            );
            parametros.Id = id;

            return parametros;
        }
        public async Task<bool> GuardarMasivoAsync(GuardarPersonaDsctoMasivoCommand request)
        {
            // Dentro de GuardarMasivoAsync
            var parameters = new
            {
                pSeleccionoTodos = request.SeleccionoTodos,
                pIdsSeleccionados = request.IdsSeleccionados != null ? string.Join(",", request.IdsSeleccionados) : null,
                pIdsExcluidos = request.IdsExcluidos != null ? string.Join(",", request.IdsExcluidos) : null,
                pFechaInicio = request.FechaInicio,
                pFechaFin = request.FechaFin,
                pValorDescuento = request.ValorDescuento,
                pIdUsuario = request.IdUsuario,
                pNombre = request.ListarParametros?.Nombre,
                pCodTipoPersona = request.ListarParametros?.CodTipoPersona,
                pIdTipoDocumento = request.ListarParametros?.IdTipoDocumento,
                pNumeroDocumento = request.ListarParametros?.NumeroDocumento
            };

            var result = await _dapperCommandService.ExecuteScalarAsync("uspSetPersonaDescuentoMasivo", parameters);

            return result > 0;
        }
    }
}
