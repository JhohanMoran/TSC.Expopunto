namespace TSC.Expopunto.Domain.Entities.PersonaDescuento
{
    public class PersonaDescuentoEntity
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal ValorDescuento { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
