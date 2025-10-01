using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar
{
    public record ActualizarVentaCommand(
        OperationType Operation,

        int Id,
        DateTime? Fecha,
        string Hora,
        int? IdSede,
        int? IdTipoComprobante,
        string? Serie,
        string? Numero,
        int? IdPersona,
        int? IdTipoMoneda,
        int? IdUsuarioVendedor,
        int? IdUsuario,
        bool? Activo,   

        List<DetalleVentaCommand>? Detalles

    ) : IRequest<VentaDTO>;
}
