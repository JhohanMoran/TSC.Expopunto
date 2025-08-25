
namespace TSC.Expopunto.Application.DataBase.Perfil.Commands
{
    public interface IPerfilCommand
    {
        Task<PerfilModel> ProcesarAsync(PerfilModel model);
    }
}
