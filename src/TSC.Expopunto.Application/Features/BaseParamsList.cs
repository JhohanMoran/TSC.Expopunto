namespace TSC.Expopunto.Application.Features
{
    public class BaseParamsList
    {
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
        public string? OrdenPor { get; set; }
        public string? OrdenDireccion { get; set; }

        public Dictionary<string, object> ParametrosAdicionales { get; set; } = new();
    }
}
