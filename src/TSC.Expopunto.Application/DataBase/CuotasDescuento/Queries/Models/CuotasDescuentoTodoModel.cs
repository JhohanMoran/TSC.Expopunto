namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models
{
    public class CuotasDescuentoTodoModel
    {
        public string DocumentoCliente { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string FechaEmision { get; set; }
        public string HoraVenta { get; set; }
        public string Vendedor { get; set; }
        public string SerieDocumento { get; set; }
        public string NumeroDocuemto { get; set; }
        public string NumDocumFinal { get; set; }
        public decimal MontoPlanilla { get; set; }
        public string Empresa { get; set; }
        public int CantBolsas { get; set; }
        public int UnidadesVendida { get; set; }
        public string TipoPago { get; set; }
        public string Estado { get; set; }
        public string NumeroSemana { get; set; }
        public string Planilla { get; set; }
        public int Cuotas { get; set; }
        public int TotalRegistros { get; set; }
    }
}
