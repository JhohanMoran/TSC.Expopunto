using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands
{
    public class DescuentoProductoVarianteModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public int IdDescuento { get; set; }
        public int IdProductoVariante { get; set; }

        public int IdUsuario { get; set; }
        public bool Activo { get; set; }
        public int TotalRegistros { get; set; }
    }
}
