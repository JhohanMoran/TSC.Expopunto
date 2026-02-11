using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSige.Params
{
    public class ObtenerGuiasConformeSigeParams : BaseParamsList
    {
        public string? Opcion { get; set; } = string.Empty;
        public string? Serie { get; set; } = string.Empty;
        public string? Numero { get; set; } = string.Empty;
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }
    }
}
