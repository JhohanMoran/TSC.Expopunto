using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Crear
{
    public class EliminarVentaHandler : IRequestHandler<EliminarVentaCommand, int>
    {
        private readonly IVentaRepository _repository;

        public EliminarVentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EliminarVentaCommand request, CancellationToken cancellationToken)
        {
            var ventaExistente = await _repository.ObtenerVentaPorIdAsync(request.Id);

            if (ventaExistente is null)
                throw new KeyNotFoundException($"No se encontró la venta con ID {request.Id}");

            var ventaId = await _repository.EliminarVentaAsync(request.Id, request.IdUsuario);

            return ventaId;
        }

    }
}
