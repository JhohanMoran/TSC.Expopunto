using MediatR;
using TSC.Expopunto.Application.DataBase.VentaTipoOperacion.DTO;

namespace TSC.Expopunto.Application.DataBase.VentaTipoOperacion.Queries
{
    public record ObtenerVentaTiposOperacionQuery() : IRequest<List<VentaTipoOperacionDTO>>;
}
