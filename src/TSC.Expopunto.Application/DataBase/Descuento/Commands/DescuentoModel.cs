using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;

namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public class DescuentoModel
    {
        public int Opcion {  get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }

        public List<DescuentoProductoVarianteModel> Detalles { get; set; }
    }
}
