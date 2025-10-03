namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO
{
    public class VentasFormaPagoDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string VentaDescripcionFormaPago { get; set; }
        public decimal Monto { get; set; }
        public string ReferenciaPago { get; set; }

        public int IdFormaPago { get; set; }
        public string FormaPago { get; set; }
        public string RutaIcono { get; set; }
        public bool Activo { get; set; }
    }
}
