using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries.Models
{
    public class ReporteModel
    {
        public int Id { get; set; }
        public string Sucursal { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty; // dd/MM/yyyy
        public string TipoCom { get; set; } = string.Empty;
        public string SerieNumero { get; set; } = string.Empty;
        public string RucDni { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Moneda { get; set; } = string.Empty;
        public decimal EFECTIVO { get; set; }
        public decimal TARJETA_DEBITO { get; set; }
        public decimal TARJETA_CREDITO { get; set; }
        public decimal DSCTO_PLANILLA { get; set; }
        public decimal PLIM { get; set; }
        public decimal YAPE { get; set; }
        public decimal TotalFactura { get; set; }
        public int TotalRegistros { get; set; }
    }
}
