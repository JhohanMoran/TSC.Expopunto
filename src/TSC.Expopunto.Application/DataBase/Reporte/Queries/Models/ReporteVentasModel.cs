namespace TSC.Expopunto.Application.DataBase.Reporte.Queries.Models
{
    public class ReporteVentasModel
    {
        public int Id { get; set; }
        public string Sucursal { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty; // dd/MM/yyyy
        public string TipoCom { get; set; } = string.Empty;
        public string SerieNumero { get; set; } = string.Empty;
        public string RucDni { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Moneda { get; set; } = string.Empty;
        public decimal Efectivo { get; set; }
        public decimal TarjetaDebito { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal DsctoPlanilla { get; set; }
        public decimal PLIM { get; set; }
        public decimal YAPE { get; set; }
        public decimal TotalFactura { get; set; }
        public int TotalRegistros { get; set; }
    }
}
