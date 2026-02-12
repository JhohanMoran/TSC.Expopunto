using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Queries.ListarDescuentosPorIdPersona
{
    public record ListarDescuentosPorIdPersonaQuery(int IdPersona) : IRequest<List<PersonaDescuentoDTO>>;
}
