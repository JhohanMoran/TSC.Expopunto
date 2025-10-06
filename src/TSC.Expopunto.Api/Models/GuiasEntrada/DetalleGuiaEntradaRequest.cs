namespace TSC.Expopunto.Api.Models.GuiasEntrada
{
    public class DetalleGuiaEntradaRequest
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; set; }
        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdTalla { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Caja { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
