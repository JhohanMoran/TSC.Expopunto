using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSC.Expopunto.Domain.Entities.Cliente;

namespace TSC.Expopunto.Persistence.Configuration
{
    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<ClienteEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.id);
            entityBuilder.Property(x => x.numeroDocumento).IsRequired();
            entityBuilder.Property(x => x.nombres).IsRequired();

            entityBuilder.HasMany(x => x.comprobantes)
                .WithOne(x => x.cliente)
                .HasForeignKey(x => x.clienteId);
        }
    }
}
