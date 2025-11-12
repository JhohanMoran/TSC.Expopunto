using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja;
using TSC.Expopunto.Application.Interfaces.Repositories.Estado;
using TSC.Expopunto.Domain.Entities.DocumentoEstado;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja;
using TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.AnularVenta
{
    public class AnularVentaHandler : IRequestHandler<AnularVentaCommand, DocumentoEstadoDTO?>
    {
        private readonly IDocumentoEstadoRepository _documentoEstadoRepository;
        private readonly IDocumentoEstadoBajaRepository _documentoEstadoBajaRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDocumentoEstadoMotivoBajaRepository _documentoEstadoMotivoBajaRepository;

        public AnularVentaHandler(
            IDocumentoEstadoRepository documentoEstadoRepository,
            IDocumentoEstadoBajaRepository documentoEstadoBajaRepository,
            IEstadoRepository estadoRepository,
            IDocumentoEstadoMotivoBajaRepository documentoEstadoMotivoBajaRepository
            )
        {
            _documentoEstadoRepository = documentoEstadoRepository;
            _documentoEstadoBajaRepository = documentoEstadoBajaRepository;
            _estadoRepository = estadoRepository;
            _documentoEstadoMotivoBajaRepository = documentoEstadoMotivoBajaRepository;
        }
        public async Task<DocumentoEstadoDTO?> Handle(AnularVentaCommand request, CancellationToken cancellationToken)
        {
            int idTipoProceso = 2; // 1:GUIA - 2:VENTAS
            int idReferencia = request.IdVenta ?? 0;

            var estados = await _estadoRepository.ListarTodosAsync();
            var estadoAnulado = estados.Find(x => x.CodigoEstadosBase == "ANUL" && x.Activo);

            var parametroEstado = new DocumentoEstadoEntity(
                0, 
                idTipoProceso,
                idReferencia,
                estadoAnulado?.Id,
                request.IdUsuario
            ); 

            var respuestaEstado = await _documentoEstadoRepository.GuardarAsync(parametroEstado);

            if (respuestaEstado == null)
            {
                throw new Exception("El estado de anulación no se registro correctamente");
            }

            var parametroEstadoBaja = new DocumentoEstadoBajaEntity(
                0,
                respuestaEstado.Id,
                request.IdUsuario
            );

            var respuestaEstadoBaja = await _documentoEstadoBajaRepository.GuardarAsync(parametroEstadoBaja);

            if (respuestaEstado == null)
            {
                throw new Exception("El estado de anulación de baja no se registro correctamente");
            }

            var parametroEstadoMotivoBaja = new DocumentoEstadoMotivoBajaEntity(
                0,
                respuestaEstado.Id,
                request.IdMotivoBaja,
                request.Observacion
            );

            var respuestaEstadoMotivo = await _documentoEstadoMotivoBajaRepository.GuardarAsync(parametroEstadoMotivoBaja);

            if (respuestaEstadoMotivo == null)
            {
                throw new Exception("El motivo de la anulación no se registró correctamente");
            }

            var respuesta = await _documentoEstadoRepository.ObtenerDocumentoEstadoPorIdAsync(respuestaEstado.Id);

            return respuesta;
        }
    }
}
