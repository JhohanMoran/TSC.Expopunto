namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class DetalleVentaEntity
    {
        public int Id { get; private set; }
        public int IdVenta { get; private set; }
        public int IdProductoVariante { get; private set; }
        public int IdTipoOperacion { get; set; }
        public int CodigoTipoOperacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public bool AplicaICBP { get; private set; }
        public int IdDescuento { get; private set; }
        public decimal ValorDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public bool Activo { get; set; }

        public DetalleVentaEntity(
            int id,
            int idVenta,
            int idProductoVariante,
            int idTipoOperacion,
            int codigoTipoOperacion,
            string descripcion,
            int cantidad,
            decimal precioUnitario,
            bool aplicaICBP,
            int idDescuento,
            decimal valorDescuento,
            decimal subTotal,
            bool activo
        )
        {
            this.Id = id;
            this.IdVenta = idVenta;
            this.IdProductoVariante = idProductoVariante;
            this.IdTipoOperacion = idTipoOperacion;
            this.CodigoTipoOperacion = codigoTipoOperacion;
            this.Descripcion = descripcion; 
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.AplicaICBP = aplicaICBP;   
            this.IdDescuento = idDescuento;
            this.ValorDescuento = valorDescuento;
            this.SubTotal = subTotal;
            this.Activo = activo;
        }

        public DetalleVentaEntity(int id, int idVenta)
        {
            this.Id = id;
            this.IdVenta = idVenta;
        }

        public void AsignarId(int id, int idVenta)
        {
            Id = id;
            IdVenta = idVenta;
        }

    }
}
