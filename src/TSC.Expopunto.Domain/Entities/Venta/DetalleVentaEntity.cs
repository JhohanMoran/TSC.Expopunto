namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class DetalleVentaEntity
    {
        public int Id { get; private set; }
        public int IdVenta { get; private set; }
        public int IdProducto { get; private set; }
        public int IdTalla { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public bool Activo { get; set; }

        public DetalleVentaEntity(
            int id,
            int idVenta,
            int idProducto,
            int idTalla,
            int cantidad,
            decimal precioUnitario,
            bool activo
        )
        {
            this.Id = id;
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.IdTalla = idTalla;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
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
