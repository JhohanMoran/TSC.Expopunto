namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Commands
{
    public class TipoDocumentoModel
    {
        public int opcion { get; set; }
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcionLarga { get; set; }
        public string descripcionCorta { get; set; }
        public int idUsuario { get; set; }
        public bool activo { get; set; }
    }
}
