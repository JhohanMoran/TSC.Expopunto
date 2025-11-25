using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentaPorSerieNumero
{
    public record ObtenerVentaPorSerieNumeroQuery(string Serie, string Numero) : IRequest<VentaDTO?>;
}
