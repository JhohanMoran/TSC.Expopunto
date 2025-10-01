using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; }
        public int? IdSede { get; set; }
        public string Sede { get; set; }
        public int? IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public int? IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public string DocumentoPersona { get; set; }
        public int? IdTipoMoneda { get; set; }
        public string SimboloMoneda { get; set; }
        public int? IdUsuarioVendedor { get; set; }
        public string NombreVendedor { get; set; }

        public decimal DescuentoTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public int? IdUsuario { get; set; }
        public bool? Activo { get; set; }

        public List<DetalleVentaDTO> Detalles { get; set; } = new();

        public int TotalRegistros { get; set; }
    }
}
