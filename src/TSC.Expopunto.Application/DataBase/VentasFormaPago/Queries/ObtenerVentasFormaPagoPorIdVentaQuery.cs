using MediatR;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;

namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.Queries
{
    public record ObtenerVentasFormaPagoPorIdVentaQuery(int idVenta) : IRequest<List<VentasFormaPagoDTO>>;
}
