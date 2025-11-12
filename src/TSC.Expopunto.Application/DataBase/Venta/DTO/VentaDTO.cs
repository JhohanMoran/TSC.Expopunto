using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; } = string.Empty;
        public int? IdSede { get; set; }
        public string Sede { get; set; } = string.Empty;
        public int? IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; } = string.Empty;
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public int? IdPersona { get; set; }
        public string NombrePersona { get; set; } = string.Empty;
        public string DocumentoPersona { get; set; } = string.Empty;
        public int? IdTipoMoneda { get; set; }
        public string SimboloMoneda { get; set; } = string.Empty;
        public int? IdUsuarioVendedor { get; set; }
        public string NombreVendedor { get; set; } = string.Empty;

        public decimal? DescuentoTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }

        public int? IdUsuario { get; set; }
        public bool? Activo { get; set; }


        public List<DetalleVentaDTO> Detalles { get; set; } = new();
        public List<VentasFormaPagoDTO> FormasPago { get; set; } = new();

        public int TotalRegistros { get; set; }
    }
}
