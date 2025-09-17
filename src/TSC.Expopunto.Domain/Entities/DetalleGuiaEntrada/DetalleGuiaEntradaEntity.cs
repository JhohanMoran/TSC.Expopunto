using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Domain.Entities.DetalleGuiaEntrada
{
    public class DetalleGuiaEntradaEntity
    {
        public int Id { get; set; }
        public int GuiaEntradaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
    }
}
