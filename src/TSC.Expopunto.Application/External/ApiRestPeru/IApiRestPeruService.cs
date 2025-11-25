using TSC.Expopunto.Application.DTOs.ApiRestPeru;

namespace TSC.Expopunto.Application.External.ApiRestPeru
{
    public interface IApiRestPeruService
    {
        Task<PersonaDto?> ObtenerPersonaPorDniAsync(string dni);
        Task<PersonaDto?> ObtenerDatosEmpresaPorDniAsync(string ruc);
    }
}
