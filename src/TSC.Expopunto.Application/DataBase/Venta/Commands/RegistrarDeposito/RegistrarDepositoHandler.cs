using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.RegistrarDeposito
{
    public class RegistrarDepositoHandler : IRequestHandler<RegistrarDepositoCommand, bool>
    {
        private readonly IVentaRepository _repository;

        public RegistrarDepositoHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RegistrarDepositoCommand request, CancellationToken cancellationToken)
        {
            // Convertimos la lista a cadena para el procedimiento almacenado
            var idsString = string.Join(",", request.IdsVentas);

            // Llamamos al repositorio que ejecutará uspSetDepositos
            return await _repository.RegistrarDepositoAsync(
                request.NroOperacion,
                request.Fecha,
                request.IdUsuario,
                idsString
            );
        }
    }
}