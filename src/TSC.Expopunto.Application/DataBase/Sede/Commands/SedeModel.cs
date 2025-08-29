using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public class SedeModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }



    }
}
