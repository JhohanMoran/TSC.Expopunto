namespace TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands
{
    public record DetalleGuiaEntradaCommand
    (
        int Id,
        int IdGuiaEntrada,
        int IdProducto,
        int IdUnidadMedida,
        int IdTalla,
        decimal Cantidad,
        decimal CostoUnitario,
        string Caja,
        string CodigoEstilo,
        string CodigoPedido,
        int IdUsuario
    );
}
