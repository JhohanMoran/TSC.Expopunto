namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models
{
    public class ProductosVarianteModel
    {
        public int Id { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CodigoTalla { get; set; } = string.Empty;
        public string Talla { get; set; } = string.Empty;
        public string descripcionDetalleVenta { get; set; } = string.Empty;

        public decimal PrecioVenta { get; set; }
        public decimal PrecioCosto { get; set; }

        public string Simbolo { get; set; } = string.Empty;

        public string TipoDescuento { get; set; } = string.Empty;
        public decimal ValorDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal PrecioFinal { get; set; }

        public bool AplicaICBP { get; set; }
        public int IdTipoOperacion { get; set; }
        public int CodigoTipoOperacion { get; set; }

        public int TotalRegistros { get; set; }
    }
}
