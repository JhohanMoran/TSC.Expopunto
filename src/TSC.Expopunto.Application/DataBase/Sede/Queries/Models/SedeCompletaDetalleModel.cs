using TSC.Expopunto.Application.DataBase.Sede.Commands;

namespace TSC.Expopunto.Application.DataBase.Sede.Queries.Models
{
    public class SedeCompletaDetalleModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public List<SedeSerieItem> Series { get; set; } = new();
    }
}
