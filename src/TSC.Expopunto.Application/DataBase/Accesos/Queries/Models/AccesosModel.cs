namespace TSC.Expopunto.Application.DataBase.Accesos.Queries.Models
{
    public class AccesosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Icono { get; set; }
        public int? IdMenuPadre { get; set; }
        public int Orden { get; set; }

        // Permisos
        public bool PuedeLeer { get; set; }
        public bool PuedeEscribir { get; set; }

        // Relación
        public List<AccesosModel> Hijos { get; set; } = new();
    }
}
