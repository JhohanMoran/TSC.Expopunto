namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models
{
    public class ProductosVariante
    {
        public int Id { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CodigoTalla { get; set; } = string.Empty;
        public string DescripcionProductoVenta { get; set; } = string.Empty;

        public int TotalRegistros { get; set; }
    }
}
