using MediatR;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.ObtenerPersonaPorNumDoc
{
    public record ObtenerPersonaPorNumDocQuery(PersonasListaParametros parametro) : IRequest<PagedResult<PersonaTodosModel>?>;
}
