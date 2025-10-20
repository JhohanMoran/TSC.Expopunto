using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Commands
{
    public class SedeSerieModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public int IdSede { get; set; }
        public int IdTipoComprobante { get; set; }
        public string Serie { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
