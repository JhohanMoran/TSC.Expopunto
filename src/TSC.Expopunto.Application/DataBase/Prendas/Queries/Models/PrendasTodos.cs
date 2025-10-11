namespace TSC.Expopunto.Application.DataBase.Prendas.Queries.Models
{
    public class PrendasTodos
    {
        public string NumCaja { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string CodigoFabrica { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
        public string CodigoPresentacion { get; set; } = string.Empty;
        public string CodigoColor { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string SubLinea { get; set; } = string.Empty;
        public string TipoPrenda { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public Dictionary<string, int> Tallas { get; set; } = new Dictionary<string, int>();

    }
}
