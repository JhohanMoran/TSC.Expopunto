namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class DetalleGuiaEntradaDTO
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; set; }
        public int IdProducto { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public int IdUnidadMedida { get; set; }
        public string CodUniMed { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Caja { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
    }
}
