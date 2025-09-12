using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands
{
    public class GuiaEntradaModel
    {
        public int Opcion {  get; set; }
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPersonaProveedor { get; set; }
        public string TipoGuia {  get; set; }
        public string Observacion { get; set; }
    }
}
