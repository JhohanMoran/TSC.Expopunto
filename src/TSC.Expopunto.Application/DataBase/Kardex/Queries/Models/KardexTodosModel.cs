namespace TSC.Expopunto.Application.DataBase.Kardex.Queries.Models
{
    public class KardexTodosModel
    {
        public int IdProductoVariante { get; set; }
        public string CodigoSKU { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdTalla { get; set; }
        public string Talla { get; set; }
        public int IdColor { get; set; }
        public string Color { get; set; }
        public decimal CantidadEntradas { get; set; }
        public decimal CostoEntradas { get; set; }
        public decimal CantidadSalidas { get; set; }
        public decimal StockActual { get; set; }
        public decimal CostoUnitarioPromedio { get; set; }
        public decimal ValorStockActual { get; set; }
        public int TotalRegistros { get; set; }
    }
}
