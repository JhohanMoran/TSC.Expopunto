namespace TSC.Expopunto.Application.DataBase.Perfil.Queries.Models
{
    public class PerfilesTodosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
        public int TotalRegistros { get; set; }
    }
}
