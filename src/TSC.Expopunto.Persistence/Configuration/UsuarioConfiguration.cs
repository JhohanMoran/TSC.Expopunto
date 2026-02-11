using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSC.Expopunto.Domain.Entities.Usuario;

namespace TSC.Expopunto.Persistence.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<UsuarioEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.id);
            entityBuilder.Property(x => x.nombres).IsRequired();
            entityBuilder.Property(x => x.apellidos).IsRequired();
            entityBuilder.Property(x => x.usuario).IsRequired();
            entityBuilder.Property(x => x.contrasenia).IsRequired();

            entityBuilder.HasMany(x => x.comprobantes)
                .WithOne(x => x.usuario)
                .HasForeignKey(x => x.usuarioId);
        }
    }
}
