namespace TSC.Expopunto.Application.DataBase.Parametro.Queries.Models
{
    public class ParametrosFormulaVenta
    {
        public string SubTotalDetalle { get; set; } = string.Empty;
        public string OperacionesGravadas { get; set; } = string.Empty;
        public string OperacionesExoneradas { get; set; } = string.Empty;
        public string OperacionesInafectas { get; set; } = string.Empty;
        public string OperacionesGratuitas { get; set; } = string.Empty;
        public string TotalDescuento { get; set; } = string.Empty;
        public string IGV { get; set; } = string.Empty;
        public string TotalICBPER { get; set; } = string.Empty;
        public string ImporteTotal { get; set; } = string.Empty;
    }
}
