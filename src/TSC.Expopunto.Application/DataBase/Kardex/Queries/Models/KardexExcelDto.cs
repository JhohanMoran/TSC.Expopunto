using System.ComponentModel.DataAnnotations;

namespace TSC.Expopunto.Application.DataBase.Kardex.Queries.Models
{
    public class KardexExcelDto
    {
        [Display(Name = "Código SKU")]
        public string CodigoSKU { get; set; }

        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        [Display(Name = "Talla")]
        public string Talla { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Cantidad Entradas")]
        public decimal CantidadEntradas { get; set; }

        [Display(Name = "Costo Entradas")]
        public decimal CostoEntradas { get; set; }

        [Display(Name = "Cantidad Salidas")]
        public decimal CantidadSalidas { get; set; }

        [Display(Name = "Stock Actual")]
        public decimal StockActual { get; set; }

        [Display(Name = "Costo Unitario Promedio")]
        public decimal CostoUnitarioPromedio { get; set; }

        [Display(Name = "Valor Stock Actual")]
        public decimal ValorStockActual { get; set; }
    }
}
