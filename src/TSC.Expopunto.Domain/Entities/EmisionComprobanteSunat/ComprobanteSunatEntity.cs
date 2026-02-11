namespace TSC.Expopunto.Domain.Entities.EmisionComprobanteSunat
{
    public class ComprobanteSunatEntity
    {
        public string CodFacturacion { get; set; } = string.Empty;
        public decimal Ordenar { get; set; }
        public int IdUsuario { get; set; }
    }
}
