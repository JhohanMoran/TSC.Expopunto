namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands
{
    public class EntidadFinancieraModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
