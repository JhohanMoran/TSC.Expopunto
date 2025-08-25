using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Perfil.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Perfil.Queries
{
    public interface IPerfilQuery
    {
        Task<List<PerfilesTodosModel>> ListarPerfilesPorEstadoAsync(bool? activo);
        Task<List<PerfilesTodosModel>> ListarComboPerfilesAsync();
        Task<PerfilesTodosModel> ListarPerfilesPorIdAsync(int idPerfil);
    }
}
