using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Queries.Models
{
    public class SedeSerieTodosModel
    {
        public int Id { get; set; }
        public int IdSede { get; set; }
        public string SedeNombre { get; set; }
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
        public int TotalRegistros { get; set; }
    }
}

