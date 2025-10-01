namespace TSC.Expopunto.Application.DataBase.DetalleVenta.DTO
{
    public class DetalleVentaDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProductoVariante { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdDescuento { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public bool Activo { get; set; }

        public string TipoDescuento { get; set; }
    }
}
