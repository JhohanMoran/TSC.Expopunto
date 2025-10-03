namespace TSC.Expopunto.Api.Models.Ventas
{
    public class DetalleVentaRequest
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProductoVariante { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdDescuento { get; set; }
        public bool Activo { get; set; }

    }
}