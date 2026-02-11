namespace TSC.Expopunto.Application.DataBase.TipoMoneda.Queries.Models
{
    public class TiposMonedaTodosModel

    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Simbolo { get; set; }
        public string NombreSingular { get; set; }
        public string NombrePlural { get; set; }

        public string Estado { get; set; }

        public int totalRegistros { get; set; }

    }
}
