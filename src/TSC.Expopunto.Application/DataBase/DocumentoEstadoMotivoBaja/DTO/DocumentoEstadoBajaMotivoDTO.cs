namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.DTO
{
    public class DocumentoEstadoBajaMotivoDTO
    {
        public int Id { get; set; }
        public int IdDocumentoEstado { get; set; }
        public int IdMotivoBaja { get; set; }
        public string NombreMotivoBaja { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
    }
}
