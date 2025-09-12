using MediatR;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta
{
    public record EliminarVentaCommand(
        OperationType Operation,
        int Id,
        int IdUsuario
    ) : IRequest<int>;
}
