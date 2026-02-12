using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaDeposito
{
    public class ListarVentasParaDepositoHandler : IRequestHandler<ListarVentasParaDepositoQuery, List<VentaDepositoDTO>>
    {
        private readonly IVentaRepository _repository;

        public ListarVentasParaDepositoHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VentaDepositoDTO>> Handle(ListarVentasParaDepositoQuery request, CancellationToken cancellationToken)
        {
            // Este método en el repositorio ejecutará uspGetDepositos
            return await _repository.ListarVentasParaDepositoAsync(request.Fecha);
        }
    }
}