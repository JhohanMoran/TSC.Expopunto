namespace TSC.Expopunto.Application.DataBase.LineaCredito.Queries.Models
{
    public class LineaCreditoTodoModel
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoConsumido { get; set; }
        public string Auditoria { get; set; }

        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombresApellidos { get; set; }
        public bool activo { get; set; }
        public string FechaAltaDisplay { get; set; }
        public string FechaBajaDisplay { get; set; }

        public decimal MontoDisponible { get; set; }
    }
}
