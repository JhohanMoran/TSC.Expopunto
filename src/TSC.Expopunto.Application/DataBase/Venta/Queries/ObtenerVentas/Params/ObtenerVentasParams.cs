using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params
{
    public class ObtenerVentasParams : BaseParamsList
    {
        public string? Serie { get; set; }
        public string? Numero { get; set; }
    }
}
