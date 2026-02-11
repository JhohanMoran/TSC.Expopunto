using TSC.Expopunto.Domain.Entities.Comprobante;

namespace TSC.Expopunto.Domain.Entities.Cliente
{
    public class ClienteEntity
    {
        public int id { get; set; }
        public string numeroDocumento { get; set; }
        public string nombres { get; set; }

        public ICollection<ComprobanteEntity> comprobantes { get; set; }

    }
}
