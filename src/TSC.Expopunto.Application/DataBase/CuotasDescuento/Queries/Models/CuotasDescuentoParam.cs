using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.CuotasDescuento.Queries.Models
{
    public class CuotasDescuentoParam : BaseParamsList
    {
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public int? IdTipoComprobante { get; set; }
        public string? CodTipoTrabajador { get; set; }
    }
}
