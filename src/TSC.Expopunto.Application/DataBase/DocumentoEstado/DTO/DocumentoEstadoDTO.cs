namespace TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO
{
    public class DocumentoEstadoDTO
    {
        public int? Id { get; set; }
        public int? IdReferencia { get; set; }
        public int? IdEstado { get; set; }
        public string? NombreEstado { get; set; } = string.Empty;
        public string? FechaRegistroDisplay { get; set; } = string.Empty;
        public int? IdUsuario { get; set; }
        
        public string? CodigoEstadoBase { get; set; } = string.Empty;
        public string? ColorEstadoBase { get; set; } = string.Empty;

        public string? Usuario { get; set; } = string.Empty;
        public string? NombreCompletoUsuario { get; set; } = string.Empty;
    }
}
