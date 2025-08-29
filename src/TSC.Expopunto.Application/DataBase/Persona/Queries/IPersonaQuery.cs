using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries
{
    public interface IPersonaQuery
    {
        Task<List<PersonaTodosModel>> ListarTodosAsync();
        Task<PersonaTodosModel> ObtenerPersonaPorIdAsync(int idPersona);
    }
}
