using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Queries
{
    public interface IUsuariosSedeQuery
    {
        Task<List<UsuariosSedeTodoModel>> ListarUsuariosSedesAsync(UsuariosSedeParam param);
        Task<UsuariosSedeTodoModel> ObtenerUsuarioSedePorPKsAsync(int idUsuario, int idSede);
    }
}
