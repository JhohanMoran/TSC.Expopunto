namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Commands
{
    public record DetalleVentaCommand(
        int Id,
        int IdVenta,
        int IdProductoVariante,
        int Cantidad,
        decimal PrecioUnitario,
        int IdDescuento,
        bool Activo
    );
}
