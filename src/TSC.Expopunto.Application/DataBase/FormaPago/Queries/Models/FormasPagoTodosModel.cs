namespace TSC.Expopunto.Application.DataBase.FormaPago.Queries.Models
{
    public class FormasPagoTodosModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RutaIcono { get; set; }
        public bool Activo { get; set; }
    }
}
