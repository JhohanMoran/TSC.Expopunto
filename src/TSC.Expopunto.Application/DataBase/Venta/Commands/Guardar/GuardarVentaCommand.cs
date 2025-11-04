using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.Commands;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.Crear
{
    public record GuardarVentaCommand(
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
        decimal? DescuentoTotal,
        decimal? SubTotal,
        decimal? Impuesto,
        decimal? Total,
        int? IdUsuario,
        bool? Activo,

        List<DetalleVentaCommand>? Detalles,
        List<VentaFormaPagoCommand>? FormasPago

    ) : IRequest<VentaDTO>;
}
