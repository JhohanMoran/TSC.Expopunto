using MediatR;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands
{
    public record VentaCommand(
        OperationType Operation,

        int Id,
        DateTime? Fecha,
        int? IdTipoComprobante,
        string? Serie,
        string? Numero,
        int? IdPersonaCliente,
        int? IdTipoMoneda,
        int? IdUsuarioVendedor,
        int? IdUsuario,

        List<DetalleVentaCommand>? Detalles

    ) : IRequest<VentaDTO>;
}
