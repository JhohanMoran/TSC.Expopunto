using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models
{
    public class CuotasSofyaExcelDto
    {
        public string DocumentoCliente { get; set; }
        public decimal MontoPlanilla { get; set; }
        public int Cuotas { get; set; }
        public int ConceptoPrestamo { get; set; }
        public string NumeroSemana { get; set; }
        public string TipoDocum { get; set; }
        public string NumDocumFinal { get; set; }
        public string anio { get; set; }
        public int InicioPrestamo { get; set; }
        public string Planilla { get; set; }
    }
}
