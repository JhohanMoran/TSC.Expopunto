using TSC.Expopunto.Domain.Entities.Comprobante;

namespace TSC.Expopunto.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }

        public ICollection<ComprobanteEntity> comprobantes { get; set; }
    }
}
