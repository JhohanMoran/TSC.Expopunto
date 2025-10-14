using MediatR;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar
{
    public record EliminarDetalleGuiaEntradaCommand(int Id, int IdUsuario) : IRequest<int> { }
}
