namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaMontoDTO
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public int IdTipoMoneda { get; set; }
        public string Simbolo { get; set; }
        public decimal MontoVenta { get; set; }
    }
}
