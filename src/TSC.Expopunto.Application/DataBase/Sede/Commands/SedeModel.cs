namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public class SedeModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }

        public bool Activo { get; set; }

    }

    public class SedeCompletaModel
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; } = true; //Necesario para desactivar Sede
        public List<SedeSerieItem> Series { get; set; } = new();
    }

    public class SedeSerieItem
    {
        public int? Id { get; set; }
        public int IdTipoComprobante { get; set; }
        public string Serie { get; set; } = null!;
        public int Numero { get; set; }
    }
}
