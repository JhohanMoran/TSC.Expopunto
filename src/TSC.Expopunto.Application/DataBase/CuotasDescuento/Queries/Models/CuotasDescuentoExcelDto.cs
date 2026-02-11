using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models
{
    public class CuotasDescuentoExcelDto
    {
        [Display(Name = "Documento Cliente")]
        public string DocumentoCliente { get; set; }

        [Display(Name = "Cliente")]
        public string Cliente { get; set; }

        [Display(Name = "Sucursal")]
        public string Sucursal { get; set; }

        [Display(Name = "Fecha de Emisión")]
        public string FechaEmision { get; set; }

        [Display(Name = "Hora de Venta")]
        public string HoraVenta { get; set; }

        [Display(Name = "Vendedor")]
        public string Vendedor { get; set; }

        [Display(Name = "Serie Documento")]
        public string SerieDocumento { get; set; }

        [Display(Name = "Nro Documento")]
        public string NumeroDocuemto { get; set; }

        [Display(Name = "Nro Docum Final")]
        public string NumDocumFinal { get; set; }

        [Display(Name = "Monto Planilla")]
        public decimal MontoPlanilla { get; set; }

        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Display(Name = "Cant. Bolsas")]
        public int CantBolsas { get; set; }

        [Display(Name = "Unidades Vendida")]
        public int UnidadesVendida { get; set; }

        [Display(Name = "Tipo de Pago")]
        public string TipoPago { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Semana")]
        public string NumeroSemana { get; set; }

        [Display(Name = "Planilla")]
        public string Planilla { get; set; }

        [Display(Name = "Cuotas")]
        public int Cuotas { get; set; }
    }
}
