using MediatR;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar
{
    public class EliminarDetalleGuiaEntradaHandler : IRequestHandler<EliminarDetalleGuiaEntradaCommand, int>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        public EliminarDetalleGuiaEntradaHandler(IGuiaEntradaRepository guiaEntradaRepository)
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
        }

        public async Task<int> Handle(EliminarDetalleGuiaEntradaCommand request, CancellationToken cancellation)
        {
            var detalleGuiaEntrada = new DetalleGuiaEntradaEntity
            {
                Id = request.Id,
                IdUsuario = request.IdUsuario
            };

            return await this._guiaEntradaRepository.EliminarDetalleEntradaAsync(detalleGuiaEntrada);
        }
    }
}
