using TSC.Expopunto.Application.DataBase.MotivoBaja.DTO;

namespace TSC.Expopunto.Application.Interfaces.Repositories.MotivoBaja
{
    public interface IMotivoBajaRepository
    {
        Task<List<MotivoBajaDTO>> ListarMotivosBaja();
    }
}
