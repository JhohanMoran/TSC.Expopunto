using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Prendas.Queries.Models
{
    public class PrendasTodos
    {
        public string NumCaja { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string CodFabrica { get; set; } = string.Empty;
        public string Pedido { get; set; } = string.Empty;
        public string CodPresent { get; set; } = string.Empty;
        public string SubLinea { get; set; } = string.Empty;
        public string TipoPrenda { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public Dictionary<string, int> Tallas { get; set; } = new Dictionary<string, int>();
                
    }
}
