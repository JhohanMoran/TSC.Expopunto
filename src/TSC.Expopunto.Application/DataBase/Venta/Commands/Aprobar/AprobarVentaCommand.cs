using MediatR;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Aprobar
{
    public record AprobarVentaCommand
    (
        int IdUsuario,
        List<int> Ids
    ) : IRequest<bool>;
}
