using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class DocumentoEstadoBajaRepository : IDocumentoEstadoBajaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;

        public DocumentoEstadoBajaRepository(IDapperCommandService dapperCommandService)
        {
            _dapperCommandService = dapperCommandService;
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
    }
}
