using TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Domain.Entities.PersonaDescuento;

namespace TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento
{
    public interface IPersonaDescuentoRepository
    {
        // Añadir esta definición de método
        Task<bool> GuardarMasivoAsync(GuardarPersonaDsctoMasivoCommand request);
        Task<PersonaDescuentoEntity> ProcesarAsync(PersonaDescuentoEntity model);
        //Task<PersonaDescuentoEntity> ProcesarAsync(PersonaDescuentoEntity parametros);

        Task<List<PersonaDescuentoDTO>> ListarDescuentosPorIdPersonaAsync(int idPersona);
        Task<PersonaDescuentoDTO> ObtenerPersonaDescuentoPorIdAsync(int id);
    }
}
