namespace TSC.Expopunto.Application.DataBase.Venta.Commands
{
    public record DetalleVentaCommand(
        int Id,
        int IdVenta,
        int IdProducto,
        int IdTalla,
        int Cantidad,
        decimal PrecioUnitario
    );
}
