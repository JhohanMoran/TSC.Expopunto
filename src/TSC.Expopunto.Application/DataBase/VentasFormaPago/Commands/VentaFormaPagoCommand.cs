namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands
{
    public record VentaFormaPagoCommand(
        int Id,
        int IdVenta,
        int IdFormaPago,
        decimal Monto,
        string ReferenciaPago,
        string RutaIcono,
        bool Activo
    );
}
