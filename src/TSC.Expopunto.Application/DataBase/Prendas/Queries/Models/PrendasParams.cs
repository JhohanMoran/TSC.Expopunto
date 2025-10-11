namespace TSC.Expopunto.Application.DataBase.Prendas.Queries.Models
{
    public class PrendasParams
    {
        public string Pedido { get; set; } = string.Empty;
        public string CodigoCliente { get; set; } = string.Empty;
        public string EstiloCliente { get; set; } = string.Empty;
        public string CodPresent { get; set; } = string.Empty;
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
        public string? OrdenarPor { get; set; }
        public string? OrdenDireccion { get; set; }
    }
}
