using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries.Models
{
    public class ProductosVariantesExcelDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [Display(Name = "Código Producto")]
        public string CodProducto { get; set; }

        [Display(Name = "Prenda")]
        public string Nombre { get; set; }

        [Display(Name = "Talla")]
        public string Talla { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Display(Name = "Código SKU")]
        public string CodigoSKU { get; set; }

        [Display(Name = "Precio Costo")]
        public int PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        public int PrecioVenta { get; set; }
    }
}
