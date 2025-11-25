namespace TSC.Expopunto.Api.Models.DocumentoEstado
{
    public class AnularVentaRequest
    {
        public int IdVenta { get; set; }
        public int IdMotivoBaja { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
