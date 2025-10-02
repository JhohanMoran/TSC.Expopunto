using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class GuiaEntradaDTO
    {
        public int Id { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public int IdPersonaProveedor {get;set;}
		public string DocumentoProveedor {get;set;} = string.Empty;
		public string NombreProveedor {get;set;} = string.Empty;
		public string TipoGuia {get;set;} = string.Empty;
		public string Observacion {get;set;} = string.Empty;
		public decimal TotalCantidad {get;set;}
        public decimal TotalCosto { get; set; }

        public List<DetalleGuiaEntradaDTO> Detalles { get; set; } = new();
        public int TotalRegistros { get; set; }
    }
}
