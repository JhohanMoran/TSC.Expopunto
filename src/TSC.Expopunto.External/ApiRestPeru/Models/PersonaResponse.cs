namespace TSC.Expopunto.External.ApiRestPeru.Models
{
    public class PersonaResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public PersonaData? Data { get; set; }
    }

    public class PersonaData
    {
        public int Verificador { get; set; }
        public string Ruc { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string MarcaComercial { get; set; } = string.Empty;
        public string Prenombres { get; set; } = string.Empty;
        public string ApPrimer { get; set; } = string.Empty;
        public string ApSegundo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ubigeo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;
        public string UbiDis { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string FeNacimiento { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public int Server { get; set; }
    }

}
