namespace TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat.Params
{
    public class ObtenerComprobanteSunatParams
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTxt { get; set; } = string.Empty;
    }
}
