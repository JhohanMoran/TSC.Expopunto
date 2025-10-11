namespace TSC.Expopunto.Application.DataBase.Perfil.Commands
{
    public class PerfilModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
