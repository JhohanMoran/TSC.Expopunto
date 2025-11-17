using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class DocumentoEstadoMotivoBajaRepository : IDocumentoEstadoMotivoBajaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;
        public DocumentoEstadoMotivoBajaRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }
        public async Task<DocumentoEstadoMotivoBajaEntity> GuardarAsync(DocumentoEstadoMotivoBajaEntity parametros)
        {
            var parameters = new
            {
                Opcion = (int)OperationType.Create,
                IdDocumentoEstado = parametros.IdDocumentoEstado,
                IdMotivoBaja = parametros.IdMotivoBaja,
                Observacion = parametros.Observacion,
            };

            var idEstadoBaja = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetDocumentoEstadoMotivoBaja",
                parameters
            );

            parametros.AsignarId(idEstadoBaja);
            return parametros;
        }

        public async Task<DocumentoEstadoBajaMotivoDTO> ObtenerMotivoBajaPorIdDocEstadoAsync(int idDocumentoEstado)
        {
            var parameters = new
            {
                Opcion = 2,
                IdDocumentoEstado = idDocumentoEstado
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<DocumentoEstadoBajaMotivoDTO>("uspGetDocumentoEstadoMotivoBaja", parameters);

            return response;
        }
    }
}
