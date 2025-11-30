namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO
{
    public class VentasFormaPagoDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string VentaDescripcionFormaPago { get; set; } = string.Empty;   
        public decimal Monto { get; set; }
        public string ReferenciaPago { get; set; } = string.Empty;

        public int IdFormaPago { get; set; }
        public string FormaPago { get; set; } = string.Empty;
        public string RutaIcono { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
