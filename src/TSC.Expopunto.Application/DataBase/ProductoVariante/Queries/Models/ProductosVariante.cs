namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models
{
    public class ProductosVariante
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Color { get; set; }
        public string CodigoTalla { get; set; }
        public string DescripcionProductoVenta { get; set; }

        public int TotalRegistros { get; set; }
    }
}
