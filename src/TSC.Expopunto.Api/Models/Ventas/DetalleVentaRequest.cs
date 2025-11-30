namespace TSC.Expopunto.Api.Models.Ventas
{
    public class DetalleVentaRequest
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProductoVariante { get; set; }
        public int IdTipoOperacion { get; set; }
        public int CodigoTipoOperacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool AplicaICBP { get; set; }
        public int IdDescuento { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public bool Activo { get; set; }

    }
}