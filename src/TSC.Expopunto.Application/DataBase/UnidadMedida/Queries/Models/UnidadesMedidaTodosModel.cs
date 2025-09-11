using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.UnidadMedida.Queries.Models
{
    public class UnidadesMedidaTodosModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreSingular { get; set; }
        public string NombrePlural { get; set; }
        public string Estado { get; set; }

    }
}
