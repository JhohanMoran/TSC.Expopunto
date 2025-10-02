namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class VentaFormasPagoEntity
    {
        public int Id { get; private set; }
        public int IdVenta { get; private set; }
        public int IdFormaPago { get; private set; }
        public string DescripcionFormaPago { get; private set; }
        public decimal Monto { get; private set; }
        public string ReferenciaPago { get; private set; }

        public VentaFormasPagoEntity(
            int id,
            int idVenta,
            int idFormaPago,
            string descripcionFormaPago,
            decimal monto,
            string referenciaPago
        )
        {
            this.Id = id;
            this.IdVenta = idVenta;
            this.IdFormaPago = idFormaPago;
            this.DescripcionFormaPago = descripcionFormaPago;
            this.Monto = monto;
            this.ReferenciaPago = referenciaPago;
        }

        public VentaFormasPagoEntity(int id, int idVenta)
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
