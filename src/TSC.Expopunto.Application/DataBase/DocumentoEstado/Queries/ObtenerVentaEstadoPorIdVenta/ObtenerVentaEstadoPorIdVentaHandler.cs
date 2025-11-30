using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstado.Queries.ObtenerVentaEstadoPorIdVenta
{
    public class ObtenerVentaEstadoPorIdVentaHandler : IRequestHandler<ObtenerVentaEstadoPorIdVentaQuery, DocumentoEstadoDTO?>
    {
        private readonly IDocumentoEstadoRepository _repository;
        public ObtenerVentaEstadoPorIdVentaHandler(IDocumentoEstadoRepository repository)
        {
            _repository = repository;
        }
        public async Task<DocumentoEstadoDTO?> Handle(ObtenerVentaEstadoPorIdVentaQuery request, CancellationToken cancellationToken)
        {
            int idTipoProceso = 2; // TIPO PROCESO: VENTAS

            return await _repository.ObtenerDocumentoEstadoPorIdReferenciaAsync(idTipoProceso, request.IdReferencia);
        }
    }
}
