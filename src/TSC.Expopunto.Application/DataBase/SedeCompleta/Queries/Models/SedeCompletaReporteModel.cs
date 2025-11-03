namespace TSC.Expopunto.Application.DataBase.SedeCompleta.Queries.Models
{
    public class SedeCompletaReporteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string TiposComprobante { get; set; } = null!; // "Factura, Boleta"
        public string Series { get; set; } = null!;         // "F001, B001"
        public string Auditoria { get; set; } = null!;
    }
}
