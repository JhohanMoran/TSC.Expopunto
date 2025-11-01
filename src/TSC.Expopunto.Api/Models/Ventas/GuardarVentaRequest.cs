using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Models.Ventas
{
    public class GuardarVentaRequest
    {
        public OperationType Operation { get; set; }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; } = string.Empty;
        public int IdSede { get; set; }
        public int IdTipoComprobante { get; set; }
        public string Serie { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public int IdPersona { get; set; }
        public int IdTipoMoneda { get; set; }
        public int IdUsuarioVendedor { get; set; }
        public decimal? DescuentoTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }
        public int IdUsuario { get; set; }

        public List<DetalleVentaRequest> Detalles { get; set; } = new();
        public List<VentaFormaPagoRequest> FormasPago { get; set; } = new();
    }
}
