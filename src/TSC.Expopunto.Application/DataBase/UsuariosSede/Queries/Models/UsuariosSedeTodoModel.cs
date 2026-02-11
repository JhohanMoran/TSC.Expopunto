namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Queries.Models
{
    public class UsuariosSedeTodoModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int IdSede { get; set; }
        public string SedeNombre { get; set; }
        public string SedeDireccion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaCreacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
        public string? FechaActualizacion { get; set; }
        public string Auditoria { get; set; }
    }
}
