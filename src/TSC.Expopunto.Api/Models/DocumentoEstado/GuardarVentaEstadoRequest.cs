namespace TSC.Expopunto.Api.Models.VentaEstadoHistorial
{
    public class GuardarVentaEstadoRequest
    {
        public int? Id { get; set; }
        public int? IdVenta { get; set; }
        public int? IdEstado { get; set; }
        public int? IdEstadoBaja { get; set; }
        public int? IdMotivoBaja { get; set; }
        public int? IdUsuario { get; set; }
        public string? Observacion { get; set; } = string.Empty;
    }
}
