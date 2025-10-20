using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params
{
    public class ObtenerGuiasEntradaParams : BaseParamsList
    {
        public int Opcion { get; set; }
        public string? Serie { get; set; } = string.Empty;
        public string? Numero { get; set; } = string.Empty;
        public int? IdProveedor { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
