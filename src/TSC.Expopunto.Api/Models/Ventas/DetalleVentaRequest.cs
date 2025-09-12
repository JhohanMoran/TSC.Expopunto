namespace TSC.Expopunto.Api.Models.Ventas
{
    public class DetalleVentaRequest
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Activo { get; set; }

    }
}