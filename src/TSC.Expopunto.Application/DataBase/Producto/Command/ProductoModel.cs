namespace TSC.Expopunto.Application.DataBase.Producto.Command
{
    public class ProductoModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public int Activo { get; set; }
        public string NumCaja { get; set; } = string.Empty;
    }
}
