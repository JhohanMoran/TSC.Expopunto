namespace TSC.Expopunto.Api.Models.PersonaDescuento
{
    public class GuardarPersonaDescuentoRequest
    {
        public int? Id { get; set; }
        public int? IdPersona { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? ValorDescuento { get; set; }
        public int? IdUsuario { get; set; }
    }
}
