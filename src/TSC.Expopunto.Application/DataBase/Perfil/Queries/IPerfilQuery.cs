using TSC.Expopunto.Application.DataBase.Perfil.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Perfil.Queries
{
    public interface IPerfilQuery
    {
        Task<List<PerfilesTodosModel>> ListarPerfilesAsync(PerfilesListaParametros baseParamsList);
        Task<List<PerfilesTodosModel>> ListarPerfilesPorEstadoAsync(bool? activo);
        Task<List<PerfilesTodosModel>> ListarComboPerfilesAsync();
        Task<PerfilesTodosModel> ListarPerfilesPorIdAsync(int idPerfil);
    }
}
