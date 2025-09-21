using TSC.Expopunto.Domain.Models;

using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries
{
    public interface IPersonaQuery
    {
        Task<List<PersonaTodosModel>> ListarPersonasAsync(PersonasListaParametros parametro);
        Task<List<PersonaTodosModel>> ListarPersonasPorEstadoAsync(bool? activo);
        Task<List<PersonaTodosModel>> ListarComboPersonasAsync();
        Task<PersonaTodosModel?> ListarPersonasPorIdAsync(int idPersona);
    }
}

