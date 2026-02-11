namespace TSC.Expopunto.Application.DataBase.Estados.DTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public int IdTipoProceso { get; set; }
        public string CodigoEstadosBase { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
