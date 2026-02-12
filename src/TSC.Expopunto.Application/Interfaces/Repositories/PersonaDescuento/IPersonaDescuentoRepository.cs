using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Domain.Entities.PersonaDescuento;

namespace TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento
{
    public interface IPersonaDescuentoRepository
    {
        Task<PersonaDescuentoEntity> ProcesarAsync(PersonaDescuentoEntity parametros);

        Task<List<PersonaDescuentoDTO>> ListarDescuentosPorIdPersonaAsync(int idPersona);
        Task<PersonaDescuentoDTO> ObtenerPersonaDescuentoPorIdAsync(int id);
    }
}
