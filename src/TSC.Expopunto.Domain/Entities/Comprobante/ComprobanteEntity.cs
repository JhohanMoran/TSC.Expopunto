using TSC.Expopunto.Domain.Entities.Cliente;
using TSC.Expopunto.Domain.Entities.Usuario;

namespace TSC.Expopunto.Domain.Entities.Comprobante
{
    public class ComprobanteEntity
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string serie { get; set; }
        public string codigo { get; set; }

        public int usuarioId { get; set; }
        public int clienteId { get; set; }

        public UsuarioEntity usuario { get; set; }
        public ClienteEntity cliente { get; set; }

    }
}
