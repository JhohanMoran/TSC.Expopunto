namespace TSC.Expopunto.Application.DataBase.DetalleVenta.Commands
{
    public record DetalleVentaCommand(
        int Id,
        int IdVenta,
        int IdProductoVariante,
        int IdTipoOperacion,
        int CodigoTipoOperacion, 
        string Descripcion, 
        int Cantidad,
        decimal PrecioUnitario,
        bool AplicaICBP,    
        int IdDescuento,
        decimal ValorDescuento,
        decimal SubTotal,
        bool Activo
    );
}
