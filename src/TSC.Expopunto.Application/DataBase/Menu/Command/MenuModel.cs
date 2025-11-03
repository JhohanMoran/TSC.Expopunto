namespace TSC.Expopunto.Application.DataBase.Menu.Command
{
    public class MenuModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ruta { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public int? IdMenuPadre { get; set; }
        public int Orden { get; set; }
        public int IdUsuario { get; set; }
    }
}
