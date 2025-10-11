using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params
{
    public class ObtenerGuiasEntradaParams : BaseParamsList
    {
        public int Opcion { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
    }
}
