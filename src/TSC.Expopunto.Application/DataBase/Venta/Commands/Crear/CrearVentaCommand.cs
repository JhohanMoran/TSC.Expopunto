using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Crear
{
    public record CrearVentaCommand(
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
        bool? Activo,

        List<DetalleVentaCommand>? Detalles

    ) : IRequest<VentaDTO>;
}
