using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Queries.Models
{
    public class TiposDocumentoTodosModel
    {
        public int Id{ get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public string Estado { get; set; }
        public int TotalResgistros { get; set; }


    }
}
