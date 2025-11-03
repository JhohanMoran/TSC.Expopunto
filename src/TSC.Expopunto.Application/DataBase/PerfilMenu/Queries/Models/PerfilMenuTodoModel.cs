namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Queries.Models
{
    public class PerfilMenuTodoModel
    {
        public int IdPerfil { get; set; }
        public string PerfilDescripcion { get; set; }
        public int IdMenu { get; set; }
        public string MenuNombre { get; set; }
        public bool PuedeLeer { get; set; }
        public bool PuedeEscribir { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaCreacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
        public string? FechaActualizacion { get; set; }
    }
}
