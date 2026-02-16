namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class PersonaTodosModel
    {
        public int Id { get; set; }
        public string CodTipoPersona { get; set; } = string.Empty;
        public string TipoPersona { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string CodigoTipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string? RazonSocial { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Celular { get; set; }
        public decimal ValorDescuento { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; } = string.Empty;
        public int TotalRegistros { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoConsumido { get; set; }
        public decimal MontoConsumidoTotalSoles { get; set; }
        public decimal MontoConsumidoTotalDolares { get; set; }
        public string FechaProximaAltaDisplay { get; set; } = string.Empty;
        public string NombrePersonaDisplay { get; set; } = string.Empty;
        public string FechaAltaDisplay { get; set; } = string.Empty;

    }
}
