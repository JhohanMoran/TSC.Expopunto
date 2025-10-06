using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Descuento.Queries.Models
{
    public class DescuentosListaParametros : BaseParamsList
    {
        public string Nombre { get; set; }
        public int Pagina { get; set; } = 1;
        public int FilasPorPagina { get; set; } = 10;
        public string OrdenarPor { get; set; } = "nombre";
        public string OrdenDireccion { get; set; } = "ASC";
    }
}
