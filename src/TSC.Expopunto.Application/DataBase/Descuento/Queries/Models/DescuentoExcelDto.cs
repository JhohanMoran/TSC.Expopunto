using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Descuento.Queries.Models
{
    public class DescuentoExcelDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        public DateTime? FechaFin { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Auditoría")]
        public string Auditoria { get; set; }

        [Display(Name = "Código Producto")]
        public string CodProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Talla")]
        public string Talla { get; set; }
    }
}
