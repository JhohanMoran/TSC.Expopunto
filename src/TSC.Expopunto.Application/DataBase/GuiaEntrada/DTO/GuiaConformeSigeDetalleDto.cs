namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class GuiaConformeSigeDetalleDto
    {
        public string CodAlmacen { get; set; } = string.Empty;
        public string NumMovstk { get; set; } = string.Empty;
        public int NumCaja { get; set; }
        public string CodEstiloCliente { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int CantPrendas { get; set; }
        public string Pedido { get; set; } = string.Empty;
        public string Talla { get; set; } = string.Empty;
    }
}
