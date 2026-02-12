using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ListarVentasParaDeposito
{
    public record ListarVentasParaDepositoQuery(DateTime Fecha) : IRequest<List<VentaDepositoDTO>>;
}