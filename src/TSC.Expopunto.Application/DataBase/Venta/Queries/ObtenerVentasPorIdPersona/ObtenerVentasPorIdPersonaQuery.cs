using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentasPorIdPersona
{
    public record ObtenerVentasPorIdPersonaQuery(int IdPersona) : IRequest<List<VentaMontoDTO?>>;
}
