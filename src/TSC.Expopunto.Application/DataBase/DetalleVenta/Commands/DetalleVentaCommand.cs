namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Commands
{
    public record DetalleVentaCommand(
        int Id,
        int IdVenta,
        int IdProducto,
        int Cantidad,
        decimal PrecioUnitario,
        int IdDescuento,
        bool Activo
    );
}
