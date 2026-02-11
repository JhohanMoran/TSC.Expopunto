using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class PaginationFilter
    {
        public int Pagina { get; set; } = 1;
        public int FilasPorPagina { get; set; } = 10;
        public string FilterName { get; set; } = string.Empty;
        public string OrdenColumna { get; set; } = "Id"; //  Nueva propiedad
        public string OrdenDireccion { get; set; } = "ASC"; //  Nueva propiedad
        public bool? ActiveFilter { get; set; } = null; //  Filtro por activo/inactivo

    }
}
