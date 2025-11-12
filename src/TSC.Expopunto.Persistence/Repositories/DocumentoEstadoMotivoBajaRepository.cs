using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class DocumentoEstadoMotivoBajaRepository : IDocumentoEstadoMotivoBajaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public DocumentoEstadoMotivoBajaRepository(IDapperCommandService dapperCommandService)
        {
            _dapperCommandService = dapperCommandService;   
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
    }
}
