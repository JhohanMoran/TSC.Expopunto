namespace TSC.Expopunto.Api.Models.Ventas
{
    public class VentaAprobacionRequest
    {
        public int IdUsuario { get; set; }
        public List<int> Ids { get; set; } = new();
    }
}
