using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Producto.Queries.Models
{
    public class ProductosTodos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Auditoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
