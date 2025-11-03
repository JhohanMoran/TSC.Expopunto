namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO
{
    public class DetalleGuiaEntradaDTO
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; set; }
        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public string CodUniMed { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public string NumCaja { get; set; } = string.Empty;
        public string CodProducto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
		public int IdCategoria {get;set;}
		public string Categoria {get;set;} = string.Empty;
		public string Genero {get;set;} = string.Empty;
		public string Color {get;set;} = string.Empty;
        public string Talla { get; set; } = string.Empty;

        public decimal CantidadOriginal {
            get
            {
                return this.Cantidad;
            }
        }
        
    }
}
