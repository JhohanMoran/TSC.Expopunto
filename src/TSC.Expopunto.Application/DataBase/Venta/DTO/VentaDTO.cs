namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTipoComprobante { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public int? IdPersonaCliente { get; set; }
        public int? IdTipoMoneda { get; set; }
        public int? IdUsuarioVendedor { get; set; }
        public int? IdUsuario { get; set; }

        public List<DetalleVentaDTO> Detalles { get; set; } = new();

        public int TotalRegistros { get; set; }
    }
}
