using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSC.Expopunto.Domain.Entities.Comprobante;

namespace TSC.Expopunto.Persistence.Configuration
{
    public class ComprobanteConfiguration
    {
        public ComprobanteConfiguration(EntityTypeBuilder<ComprobanteEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.id);

            entityBuilder.Property(x => x.fecha).IsRequired();
            entityBuilder.Property(x => x.serie).IsRequired();
            entityBuilder.Property(x => x.codigo).IsRequired();

            entityBuilder.Property(x => x.usuarioId).IsRequired();
            entityBuilder.Property(x => x.clienteId).IsRequired();

            entityBuilder.HasOne(x => x.usuario)
                .WithMany(x => x.comprobantes)
                .HasForeignKey(x => x.usuarioId);

            entityBuilder.HasOne(x => x.cliente)
                .WithMany(x => x.comprobantes)
                .HasForeignKey(x => x.clienteId);
        }
    }
}
