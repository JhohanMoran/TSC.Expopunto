namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Queries.Models
{
    public class TiposDocumentoTodosModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string DescripcionLarga { get; set; }
        public string DescripcionCorta { get; set; }

        public string Estado { get; set; }
        public int TotalRegistros { get; set; }


    }
}
