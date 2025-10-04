using MediatR;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;

namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.Queries
{
    public class ObtenerVentasFormaPagoPorIdVentaHandler : IRequestHandler<ObtenerVentasFormaPagoPorIdVentaQuery, List<VentasFormaPagoDTO>>
    {
        private readonly IVentaRepository _repository;
        public ObtenerVentasFormaPagoPorIdVentaHandler(IVentaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<VentasFormaPagoDTO>> Handle(ObtenerVentasFormaPagoPorIdVentaQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.ObtenerVentasFormaPagoPorIdVentaAsync(request.idVenta);
            return resultado;
        }
    }
}
