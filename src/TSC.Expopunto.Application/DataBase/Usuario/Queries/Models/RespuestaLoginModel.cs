namespace TSC.Expopunto.Application.DataBase.Usuario.Queries.Models
{
    public class RespuestaLoginModel
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Token { get; set; }
    }
}
