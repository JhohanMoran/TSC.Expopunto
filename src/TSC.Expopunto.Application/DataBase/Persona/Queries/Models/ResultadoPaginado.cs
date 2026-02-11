using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class ResultadoPaginado<T>
    {
        public List<T> Elementos { get; set; } = new();
        public int TotalElementos { get; set; }
        public int Pagina { get; set; }
        public int ElementosPorPagina { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalElementos / ElementosPorPagina);
    }
}
