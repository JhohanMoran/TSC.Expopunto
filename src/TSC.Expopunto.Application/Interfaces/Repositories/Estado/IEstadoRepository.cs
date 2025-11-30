using TSC.Expopunto.Application.DataBase.Estados.DTO;

namespace TSC.Expopunto.Application.Interfaces.Repositories.Estado
{
    public interface IEstadoRepository
    {
        Task<List<EstadoDTO>> ListarTodosAsync();
    }
}
