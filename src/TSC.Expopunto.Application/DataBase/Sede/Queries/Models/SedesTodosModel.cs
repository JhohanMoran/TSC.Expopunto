using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Sede.Queries.Models
{
    public class SedesTodosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string  Estado { get; set; }
        public int totalRegistro { get; set; }

    }
}
