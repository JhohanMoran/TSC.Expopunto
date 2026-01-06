using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class GuiaConformeSigeDto
    {
        public string CodAlmacen { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NumMovstk { get; set; } = string.Empty;
        public string FechaCreacion { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public int TotalRegistros { get; set; }
    }
}
