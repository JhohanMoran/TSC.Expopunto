using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class DetalleGuiaEntradaDTO
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; set; }
        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }

      
    }
}
