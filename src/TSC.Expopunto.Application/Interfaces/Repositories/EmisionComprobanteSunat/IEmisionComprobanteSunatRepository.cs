using TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat.Params;
using TSC.Expopunto.Domain.Entities.EmisionComprobanteSunat;

namespace TSC.Expopunto.Application.Interfaces.Repositories.EmisionComprobanteSunat
{
    public interface IEmisionComprobanteSunatRepository
    {
        Task<List<ComprobanteSunatEntity>> ObtenerComprobanteSunatAsync(ObtenerComprobanteSunatParams parametro);
    }
}
