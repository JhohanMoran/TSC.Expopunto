namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class DetalleVentaDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
