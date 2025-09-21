namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Commands
{
    public record DetalleVentaCommand(
        int Id,
        int IdVenta,
        int IdProducto,
        int IdTalla,
        int Cantidad,
        decimal PrecioUnitario,
        bool Activo
    );
}
