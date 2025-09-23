using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models
{
    public class LineaCreditoTodoModel
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoConsumido { get; set; }
        public string Auditoria { get; set; }
    }
}
