using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.Interfaces.Venta;

namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Queries
{
    public class ObtenerDetalleVentaPorIdVentaHandler : IRequestHandler<ObtenerDetalleVentaPorIdVentaQuery, List<DetalleVentaDTO>>
    {
        private readonly IVentaRepository _repository;
        public ObtenerDetalleVentaPorIdVentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DetalleVentaDTO>> Handle(ObtenerDetalleVentaPorIdVentaQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.ObtenerDetalleVentaPorIdVentaAsync(request.idVenta);
            return resultado;
        }
    }
}
