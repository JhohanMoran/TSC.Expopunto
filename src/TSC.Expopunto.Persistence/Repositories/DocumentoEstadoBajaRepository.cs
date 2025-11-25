using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class DocumentoEstadoBajaRepository : IDocumentoEstadoBajaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;

        public DocumentoEstadoBajaRepository(
            IDapperCommandService dapperCommandService, 
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }

        public async Task<DocumentoEstadoBajaEntity> GuardarAsync(DocumentoEstadoBajaEntity parametros)
        {   
            var parameters = new
            {
                Opcion = (int)OperationType.Create,
                IdDocumentoEstado = parametros.IdDocumentoEstado,
                IdUsuario = parametros.IdUsuario,
            };

            var idEstadoBaja = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetDocumentoEstadoBaja",
                parameters
            );

            parametros.AsignarId(idEstadoBaja);
            return parametros;
        }

        public async Task<DocumentoEstadoBajaDTO> ObtenerDocumentoEstadoPorIdDocEstadoAsync(int idDocumentoEstado)
        {
            var parameters = new
            {
                Opcion = 2,
                IdDocumentoEstado = idDocumentoEstado
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<DocumentoEstadoBajaDTO>("uspGetDocumentoEstadoBaja", parameters);

            return response;
        }
    }
}
