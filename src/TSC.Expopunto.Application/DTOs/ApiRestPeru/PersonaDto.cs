namespace TSC.Expopunto.Application.DTOs.ApiRestPeru
{
    public class PersonaDto
    {
        public string Dni { get; set; } = string.Empty;
        public string Ruc { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string MarcaComercial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Prenombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string Ubigeo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; } = string.Empty;

    }
}
