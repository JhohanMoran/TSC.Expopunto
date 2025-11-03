namespace TSC.Expopunto.Application.DataBase.Reporte.Queries.Models
{
    public class DetalleVentaDto
    {
        public int IdProductoVariante { get; set; }
        public string CodigoSKU { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdDescuento { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal Subtotal { get; set; }
        public string TipoDescuento { get; set; }
    }
}

