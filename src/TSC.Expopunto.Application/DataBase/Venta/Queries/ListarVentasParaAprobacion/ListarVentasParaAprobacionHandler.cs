using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaAprobacion
{
    public class ListarVentasParaAprobacionHandler : IRequestHandler<ListarVentasParaAprobacionQuery, List<VentaAprobacionDTO>>
    {
        private readonly IVentaRepository _repository;
        public ListarVentasParaAprobacionHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VentaAprobacionDTO>> Handle(ListarVentasParaAprobacionQuery request, CancellationToken cancellationToken)
        {

            return await _repository.ListarVentasParaAprobacionAsync(request.fecha);
        }
    }
}
