namespace TSC.Expopunto.Domain.Entities.DetalleVenta
{
    public class DetalleVentaEntity
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
