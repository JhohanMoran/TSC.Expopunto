namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO
{
    public class DocumentoEstadoBajaDTO
    {
        public int Id { get; set; }
        public int IdDocumentoEstado { get; set; }
        public int IdEstadoBaja { get; set; }
        public string NombreEstadoBaja { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string NombreCompletoUsuario { get; set; } = string.Empty;
    }
}
