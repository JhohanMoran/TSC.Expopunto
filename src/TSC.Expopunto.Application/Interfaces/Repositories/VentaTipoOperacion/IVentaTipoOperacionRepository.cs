using TSC.Expopunto.Application.DataBase.VentaTipoOperacion.DTO;

namespace TSC.Expopunto.Application.Interfaces.Repositories.VentaTipoOperacion
{
    public interface IVentaTipoOperacionRepository
    {
        Task<List<VentaTipoOperacionDTO>> ListarVentaTiposOperacion();
    }
}
