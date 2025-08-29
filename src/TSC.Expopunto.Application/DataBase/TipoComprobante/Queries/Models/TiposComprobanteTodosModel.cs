using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.TipoComprobante.Queries.Models
{
    public class TiposComprobanteTodosModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public int totalRegistros { get; set; }
    }
}
