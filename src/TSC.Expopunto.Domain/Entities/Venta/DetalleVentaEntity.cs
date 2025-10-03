namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class DetalleVentaEntity
    {
        public int Id { get; private set; }
        public int IdVenta { get; private set; }
        public int IdProductoVariante { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public int IdDescuento { get; private set; }
        public bool Activo { get; set; }

        public DetalleVentaEntity(
            int id,
            int idVenta,
            int idProductoVariante,
            int cantidad,
            decimal precioUnitario,
            int idDescuento,
            bool activo
        )
        {
            this.Id = id;
            this.IdVenta = idVenta;
            this.IdProductoVariante = idProductoVariante;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.IdDescuento = idDescuento;
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
