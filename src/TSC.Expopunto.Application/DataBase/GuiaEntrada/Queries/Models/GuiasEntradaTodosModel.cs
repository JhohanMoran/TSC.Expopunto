using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.Models
{
    public class GuiasEntradaTodosModel
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPersonaProveedor { get; set; }
        public string TipoGuia {  get; set; }

        public string Auditoria { get; set; }
        public int totalRegistros { get; set; }
    }
}
