using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.TipoPersona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoPersona.Queries
{
    public interface ITipoPersonaQuery
    {
        Task<List<TipoPersonaTodosModel>> ListarTodosAsync();
        Task<TipoPersonaTodosModel> ObtenerTipoPersonaPorIdAsync(int idTipoPersona);
    }
}
