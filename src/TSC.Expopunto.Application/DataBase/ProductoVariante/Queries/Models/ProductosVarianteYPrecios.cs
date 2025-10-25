namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models
{
    public class ProductosVarianteYPrecios
    {
        public int Id { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CodigoTalla { get; set; } = string.Empty;
        public string DescripcionProductoVenta { get; set; } = string.Empty;

        public decimal PrecioVenta { get; set; }
        public decimal PrecioCosto { get; set; }

        public string Simbolo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public decimal MontoDescuento { get; set; }
        public decimal PrecioFinal { get; set; }

        public int TotalRegistros { get; set; }
    }
}
