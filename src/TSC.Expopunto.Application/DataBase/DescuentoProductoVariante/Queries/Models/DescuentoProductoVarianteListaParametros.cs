using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries.Models
{
    public class DescuentoProductoVarianteListaParametros
    {
        public int? FiltroIdDescuento { get; set; }
        public int? FiltroIdVariante { get; set; }
        public int Pagina { get; set; } = 1;
        public int FilasPorPagina { get; set; } = 10;
        public string OrdenarPor { get; set; } = "IdDescuento";
        public string OrdenDireccion { get; set; } = "ASC";
    }
}
