using Microsoft.AspNetCore.Mvc.ModelBinding;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries
{
    public interface IUsuarioQuery
    {
        Task<List<UsuariosTodosModel>> ListarTodosAsync(UsuarioParam param);
        Task<UsuariosTodosModel> ObtenerUsuarioPorIdAsync(int idUsuario);
    }
}
