using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries.Models
{
    public class ReporteExcelDto
    {
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Tipo Comprobante")]
        public string TipoComprobante { get; set; }

        [Display(Name = "Serie - Número")]
        public string SerieNumero { get; set; }

        [Display(Name = "RUC / DNI")]
        public string RucDni { get; set; }

        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Display(Name = "Moneda")]
        public string Moneda { get; set; }

        [Display(Name = "Efectivo")]
        public decimal Efectivo { get; set; }

        [Display(Name = "Tarjeta Débito")]
        public decimal TarjetaDebito { get; set; }

        [Display(Name = "Tarjeta Crédito")]
        public decimal TarjetaCredito { get; set; }

        [Display(Name = "Dscto Planilla")]
        public decimal DsctoPlanilla { get; set; }

        [Display(Name = "PLIM")]
        public decimal Plim { get; set; }

        [Display(Name = "Yape")]
        public decimal Yape { get; set; }

        [Display(Name = "Total ICBPER")]
        public decimal TotalICBPER { get; set; }

        [Display(Name = "Total Factura")]
        public decimal TotalFactura { get; set; }

        [Display(Name = "Sede")]
        public string Sucursal { get; set; }
    }
}
