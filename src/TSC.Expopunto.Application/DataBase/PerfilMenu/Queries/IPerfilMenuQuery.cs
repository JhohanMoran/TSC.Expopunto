using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Queries
{
    public interface IPerfilMenuQuery
    {
        Task<List<PerfilMenuTodoModel>> ListarPerfilesMenuAsync(PerfilMenuParam param);
        Task<PerfilMenuTodoModel> ObtenerPerfilMenuPorPKsAsync(int idPerfil, int idMenu);
    }
}
