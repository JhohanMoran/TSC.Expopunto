using MediatR;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar
{
    public record EliminarGuiaEntradaCommand(int Id) : IRequest<int> { }
}
