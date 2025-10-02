using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Domain.Entities.GuiaEntrada
{
    public class DetalleGuiaEntradaEntity
    {
        public int Id { get; private set; }
        public int IdGuiaEntrada { get; private set; }
        public int IdProducto { get; private set; }
        public int IdUnidadMedida { get; private set; }
        public int IdTalla { get; private set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; private set; }
        public string Caja { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;


        public DetalleGuiaEntradaEntity(
            int id,
            int idGuiaEntrada,
            int idProducto,
            int idUnidadMedida,
            int idTalla,
            int cantidad,
            decimal costoUnitario
            
        )
        {
            this.Id = id;
            this.IdGuiaEntrada = idGuiaEntrada;
            this.IdProducto = idProducto;
            this.IdUnidadMedida = idUnidadMedida;
            this.IdTalla = idTalla;
            this.Cantidad = cantidad;
            this.CostoUnitario = costoUnitario;
            
        }

        public DetalleGuiaEntradaEntity(int id, int idGuiaEntrada)
        {
            this.Id = id;
            this.IdGuiaEntrada = idGuiaEntrada;
        }

        public void AsignarId(int id, int idGuiaEntrada)
        {
            Id = id;
            IdGuiaEntrada = idGuiaEntrada;
        }

    }
}
