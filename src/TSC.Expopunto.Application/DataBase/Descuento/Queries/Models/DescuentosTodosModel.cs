using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Descuento.Queries.Models
{
    public class DescuentosTodosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public string FechaInicioDisplay { get; set; }
        public string FechaFinDisplay { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
        public int TotalRegistros { get; set; }

    }
}
