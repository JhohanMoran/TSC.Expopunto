namespace TSC.Expopunto.Domain.Entities.Persona
{
    public class PersonaEntity
    {
        public int? Opcion { get; set; }
        public int? Id { get; set; }

        public string? CodTipoPersona { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? RazonSocial { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Celular { get; set; }

        public int? IdUsuario { get; set; }
        public bool? Activo { get; set; } = true;
        public string? DetalleMotivoBaja { get; set; }

        public PersonaEntity()
        {
                
        }
        public PersonaEntity(
            int? opcion,
            int? id,
            string? codTipoPersona,
            int? idTipoDocumento,
            string? numeroDocumento,
            string? razonSocial,
            string? nombres,
            string? apellidos,
            string? direccion,
            string? celular,
            int? idUsuario,
            bool? activo,
            string? detalleMotivoBaja
        )
        {
            Opcion = opcion;
            Id = id;
            CodTipoPersona = codTipoPersona;
            IdTipoDocumento = idTipoDocumento;
            NumeroDocumento = numeroDocumento;
            RazonSocial = razonSocial;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Celular = celular;
            IdUsuario = idUsuario;
            Activo = activo;
            DetalleMotivoBaja = detalleMotivoBaja;
        }

    }
}
