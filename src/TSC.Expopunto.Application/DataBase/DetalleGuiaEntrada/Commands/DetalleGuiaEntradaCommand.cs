namespace TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands
{
    public record DetalleGuiaEntradaCommand
    (
        int Id,
        int IdGuiaEntrada,
        int IdProducto,
        int IdUnidadMedida,
        int IdTalla,
        string Talla,
        decimal Cantidad,
        int NumCaja,
        string Nombre,
        string CodigoEstilo,
        string CodigoPedido,
        string Categoria,
        string Genero,
        string Color,
        string CodigoSku,
        int IdUsuario
    )
    {
        public int IdProducto { get; set; } = IdProducto;
    }
}
