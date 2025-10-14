using Azure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorId;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar
{
    public class EliminarGuiaEntradaHandler : IRequestHandler<EliminarGuiaEntradaCommand, int>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        public EliminarGuiaEntradaHandler(IGuiaEntradaRepository guiaEntradaRepository)
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
        }

        public async Task<int> Handle(EliminarGuiaEntradaCommand request, CancellationToken cancellationToken)
        {
            var guiaEntrada = new GuiaEntradaEntity()
            {
                Id = request.Id
            };

            return await this._guiaEntradaRepository.EliminarGuiaEntradaAsync(guiaEntrada);
            
        }
    }
}
