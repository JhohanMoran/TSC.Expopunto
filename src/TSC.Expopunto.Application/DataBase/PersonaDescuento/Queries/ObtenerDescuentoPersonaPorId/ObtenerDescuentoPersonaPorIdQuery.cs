using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ObtenerDescuentoPersonaPorId
{
    public record ObtenerDescuentoPersonaPorIdQuery(int Id) : IRequest<PersonaDescuentoDTO>;
}
