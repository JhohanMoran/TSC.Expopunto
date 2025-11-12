using MediatR;
using TSC.Expopunto.Application.DataBase.Estados.DTO;

namespace TSC.Expopunto.Application.DataBase.Estados.Queries.ListarEstados
{
    public record ListarEstadosQuery () : IRequest<List<EstadoDTO?>>;
}
