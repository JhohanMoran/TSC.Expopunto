namespace TSC.Expopunto.Application.DataBase.Producto.Queries.Models
{
    public class CategoriaParams
    {
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
        public string? Nombre { get; set; }
        public string? OrdenarPor { get; set; }
        public string? OrdenDireccion { get; set; }
        public bool? Activo { get; set; }
    }
}
