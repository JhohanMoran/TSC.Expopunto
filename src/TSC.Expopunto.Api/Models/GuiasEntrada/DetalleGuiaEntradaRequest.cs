namespace TSC.Expopunto.Api.Models.GuiasEntrada
{
    public class DetalleGuiaEntradaRequest
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; set; }
        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdTalla { get; set; }
        public string Talla { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public int NumCaja { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CodigoSku { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
