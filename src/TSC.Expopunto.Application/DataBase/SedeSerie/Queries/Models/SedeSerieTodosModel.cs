namespace TSC.Expopunto.Application.DataBase.SedeSerie.Queries.Models
{
    public class SedeSerieTodosModel
    {
        public int Id { get; set; }
        public int IdSede { get; set; }
        public string SedeNombre { get; set; } = string.Empty;
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; } = string.Empty; 
        public string Serie { get; set; } = string.Empty;
        public int Numero { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; } = string.Empty;   
        public int TotalRegistros { get; set; }
    }
}

