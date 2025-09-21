namespace TSC.Expopunto.Application.DataBase.Categoria.Queries.Models
{
    public class CategoriaTodos
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Auditoria { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
