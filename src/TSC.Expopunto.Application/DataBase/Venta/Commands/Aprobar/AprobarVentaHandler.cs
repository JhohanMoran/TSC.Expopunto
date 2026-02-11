using DocumentFormat.OpenXml.Office2010.Excel;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;
using TSC.Expopunto.Application.Interfaces.Repositories.Estado;
using TSC.Expopunto.Domain.Entities.DocumentoEstado;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Aprobar
{
    public class AprobarVentaHandler : IRequestHandler<AprobarVentaCommand, bool>
    {
        private readonly IDocumentoEstadoRepository _repository;
        private readonly IEstadoRepository _estadoRepository;
        public AprobarVentaHandler(
            IDocumentoEstadoRepository repository,
            IEstadoRepository estadoRepository
        )
        {
            _repository = repository;
            _estadoRepository = estadoRepository;
        }
        public async Task<bool> Handle(AprobarVentaCommand request, CancellationToken cancellationToken)
        {
            int idTipoProceso = 2; // 1:GUIA - 2:VENTAS
            int idReferencia = 0;

            var estados = await _estadoRepository.ListarTodosAsync();
            var estadoAprobado = estados.Find(x => x.CodigoEstadosBase == "APRO" && x.IdTipoProceso == idTipoProceso && x.Activo);

            var documentoEstadoEntity = new DocumentoEstadoEntity(
                0,
                idTipoProceso,
                idReferencia,
                estadoAprobado.Id,
                request.IdUsuario
            );

            var jsonIds = JsonConvert.SerializeObject(request.Ids);

            var respuesta = await _repository.AprobarVentaAsync(documentoEstadoEntity, jsonIds);

            return respuesta;
        }
    }
}
