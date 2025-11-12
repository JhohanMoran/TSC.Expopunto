using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TSC.Expopunto.Application.DTOs.ApiRestPeru;
using TSC.Expopunto.Application.External.ApiRestPeru;
using TSC.Expopunto.External.ApiRestPeru.Models;

namespace TSC.Expopunto.External.ApiRestPeru
{
    public class ApiRestPeruService : IApiRestPeruService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiRestPeruService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<PersonaDto?> ObtenerDatosEmpresaPorDniAsync(string ruc)
        {
            var token = _configuration["ApiRestPeru:Token"];
            var baseUrl = _configuration["ApiRestPeru:BaseUrl"];
            var url = $"{baseUrl}/search/ruc/{ruc}/{token}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PersonaResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result?.Success != true || result.Data == null)
                return null;

            var data = result.Data;

            return new PersonaDto
            {
                Ruc = data.Ruc,
                NombreCompleto = data.NombreCompleto,
                MarcaComercial = data.MarcaComercial,
                Direccion = data.Direccion,
                Ubigeo = data.Ubigeo,
                Estado = data.Estado,
                Condicion = data.Condicion,
                Departamento = data.Departamento,
                Provincia = data.Provincia,
                Distrito = data.Distrito,
                FechaNacimiento = DateTime.TryParse(data.FeNacimiento, out var fecha) ? fecha : null
            };
        }

        public async Task<PersonaDto?> ObtenerPersonaPorDniAsync(string dni)
        {
            var token = _configuration["ApiRestPeru:Token"];
            var baseUrl = _configuration["ApiRestPeru:BaseUrl"];
            var url = $"{baseUrl}/search/dni/{dni}/{token}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PersonaResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result?.Success != true || result.Data == null)
                return null;

            var data = result.Data;

            return new PersonaDto
            {
                Dni = data.Dni,
                NombreCompleto = data.NombreCompleto,
                Prenombres = data.Prenombres,
                ApellidoPaterno = data.ApPrimer,
                ApellidoMaterno = data.ApSegundo,
                Direccion = data.Direccion,
                FechaNacimiento = DateTime.TryParse(data.FeNacimiento, out var fecha) ? fecha : null,
                Sexo = data.Sexo
            };
        }

    }
}
