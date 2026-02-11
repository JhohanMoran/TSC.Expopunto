using DocumentFormat.OpenXml.Spreadsheet;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;
using TSC.Expopunto.Domain.Entities.DocumentoEstado;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class DocumentoEstadoRepository : IDocumentoEstadoRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;

        public DocumentoEstadoRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }

        public async Task<bool> AprobarVentaAsync(DocumentoEstadoEntity documentoEstado, string idsJson)
        {
            var parameters = new
            {
                Opcion = 2,
                IdTipoProceso = documentoEstado.IdTipoProceso,
                IdReferencia = documentoEstado.IdReferencia,
                IdEstado = documentoEstado.IdEstado,
                IdUsuario = documentoEstado.IdUsuario,
                IdsJson = idsJson
            };

            var rpta = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetDocumentoEstado",
                parameters
            );

            return (rpta > 0);
        }

        public async Task<DocumentoEstadoEntity> GuardarAsync(DocumentoEstadoEntity parametros)
        {
            var parameters = new
            {
                Opcion = 1,
                IdTipoProceso = parametros.IdTipoProceso,
                IdReferencia = parametros.IdReferencia,
                IdEstado = parametros.IdEstado,
                IdUsuario = parametros.IdUsuario,
            };

            var idEstado = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetDocumentoEstado",
                parameters
            );

            parametros.AsignarId(idEstado);
            return parametros;
        }

        public async Task<DocumentoEstadoDTO> ObtenerDocumentoEstadoPorIdAsync(int id)
        {
            var parameters = new
            {
                Opcion = 1,
                Id = id
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<DocumentoEstadoDTO>("uspGetDocumentoEstado", parameters);

            return response;
        }

        public async Task<DocumentoEstadoDTO> ObtenerDocumentoEstadoPorIdReferenciaAsync(int idTipoProceso, int idReferencia)
        {
            var parameters = new
            {
                Opcion = 3,
                IdTipoProceso = idTipoProceso,
                IdReferencia = idReferencia
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<DocumentoEstadoDTO>("uspGetDocumentoEstado", parameters);

            return response;
        }
    }
}
