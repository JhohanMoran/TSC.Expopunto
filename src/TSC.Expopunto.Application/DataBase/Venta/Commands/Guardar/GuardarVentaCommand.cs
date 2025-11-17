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

        int? Cantidad,
        decimal? OpGravadas,
        decimal? OpExoneradas,
        decimal? OpInafectas,
        decimal? OpGratuitas,
        decimal? TotalDescuento,
        decimal? TotalIGV,
        decimal? TotalICBPER,
        decimal? ImporteTotal,

        int? IdUsuario,
        
        List<DetalleVentaCommand>? Detalles,
        List<VentaFormaPagoCommand>? FormasPago

    ) : IRequest<VentaDTO>;
}
