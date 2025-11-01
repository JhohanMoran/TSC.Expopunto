namespace TSC.Expopunto.Api.Models.Ventas
{
    public class VentaFormaPagoRequest
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdFormaPago { get; set; }
        public string DescripcionFormaPago { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public string RutaIcono { get; set; } = string.Empty;
        public string ReferenciaPago { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
