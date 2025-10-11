namespace TSC.Expopunto.Application.DataBase.Menu.Queries.Models
{
    public class MenusTodos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ruta { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public int? IdMenuPadre { get; set; }
        public string MenuPadre { get; set; } = string.Empty;
        public string RutaJerarquica { get; set; } = string.Empty;
        public int Nivel { get; set; }
        public int Orden { get; set; }
        public int IdGrupoMenu { get; set; }
        public bool Activo { get; set; }
        public List<MenusTodos> MenuHijo { get; set; } = new List<MenusTodos>();
    }
}
