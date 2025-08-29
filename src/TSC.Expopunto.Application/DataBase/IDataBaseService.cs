using Microsoft.EntityFrameworkCore;
using System.Data;
using TSC.Expopunto.Domain.Entities.Cliente;
using TSC.Expopunto.Domain.Entities.Comprobante;
using TSC.Expopunto.Domain.Entities.Usuario;

namespace TSC.Expopunto.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<ClienteEntity> Cliente { get; set; }
        DbSet<ComprobanteEntity> Comprobante { get; set; }
        

        Task<bool> SaveAsync();
    }
}
