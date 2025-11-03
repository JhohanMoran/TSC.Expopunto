using Microsoft.EntityFrameworkCore;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Domain.Entities.Cliente;
using TSC.Expopunto.Domain.Entities.Comprobante;
using TSC.Expopunto.Domain.Entities.Usuario;
using TSC.Expopunto.Persistence.Configuration;

namespace TSC.Expopunto.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<ComprobanteEntity> Comprobante { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguration(modelBuilder.Entity<UsuarioEntity>());
            new ClienteConfiguration(modelBuilder.Entity<ClienteEntity>());
            new ComprobanteConfiguration(modelBuilder.Entity<ComprobanteEntity>());
        }

    }
}
