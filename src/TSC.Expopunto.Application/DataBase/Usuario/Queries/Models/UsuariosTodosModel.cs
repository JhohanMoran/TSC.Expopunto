namespace TSC.Expopunto.Application.DataBase.Usuario.Queries.Models
{
    public class UsuariosTodosModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
    }
}
