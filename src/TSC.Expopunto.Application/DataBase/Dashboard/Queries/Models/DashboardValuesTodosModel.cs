namespace TSC.Expopunto.Application.DataBase.Dashboard.Queries.Models
{
    public class DashboardValuesTodosModel
    {
        public decimal VentasTotales { get; set; }
        public decimal PorcentajeCambioVentas { get; set; }
        public int NumeroDeVentas { get; set; }
        public decimal PorcentajeCambioNumVentas { get; set; }
        public decimal GananciaNeta { get; set; }
        public decimal PorcentajeCambioGanancia { get; set; }
        public int ClientesNuevos { get; set; }
        public decimal PorcentajeCambioClientes { get; set; }
    }
}
