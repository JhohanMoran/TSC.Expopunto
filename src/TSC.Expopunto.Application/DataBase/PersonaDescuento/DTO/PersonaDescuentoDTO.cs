namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO
{
    public class PersonaDescuentoDTO
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal ValorDescuento { get; set; }
        public string Auditoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
