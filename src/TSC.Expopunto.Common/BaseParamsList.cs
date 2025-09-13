namespace TSC.Expopunto.Common
{
    public class BaseParamsList
    {
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
        public string? OrdenarPor { get; set; }
        public string? OrdenDireccion { get; set; }

        public Dictionary<string, object> ParametrosAdicionales { get; set; } = new();
    }
}
