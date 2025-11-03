using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Commands.Models
{
    public class ProductoVarianteModel
    {
        public int Opcion {get;set;}
        public int Id {get;set; }
        public int IdProducto {get;set;}
        public string Talla { get; set; } = string.Empty;
        public string Color {get;set;} = string.Empty;
        public string CodigoSKU { get; set; } = string.Empty;
    }
}
