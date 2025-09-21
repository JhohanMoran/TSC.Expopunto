using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Producto.Command
{
    public class ProductoModel
    {
        public int Opcion {get;set;}
        public int Id {get;set;}
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion {get;set;} = string.Empty;
        public int IdCategoria {get;set;}
        public int IdUsuario { get; set; }
    }
}
