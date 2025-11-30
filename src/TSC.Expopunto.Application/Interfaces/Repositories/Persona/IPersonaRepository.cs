using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Persona;

namespace TSC.Expopunto.Application.Interfaces.Repositories.Persona
{
    public interface IPersonaRepository
    {
        Task<PersonaEntity> ProcesarAsync(PersonaEntity parametros);
        Task<PagedResult<PersonaTodosModel>> ListarPersonasModalBusquedaAsync(PersonasListaParametros parametro);
    }
}
