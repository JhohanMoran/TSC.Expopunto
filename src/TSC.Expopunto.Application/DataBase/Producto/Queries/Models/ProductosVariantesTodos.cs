using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries.Models
{
    public class ProductosVariantesTodos
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string CodProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdTalla { get; set; }
        public string Talla { get; set; }
        public int IdColor { get; set; }
        public string Color { get; set; }
        public string Genero { get; set; }
        public string CodigoSKU { get; set; }
        public int IdHistorialPrecios { get; set; }
        public int PrecioVenta { get; set; }
        public int PrecioCosto { get; set; }
        public string Auditoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int TotalRegistros { get; set; }
    }
}
