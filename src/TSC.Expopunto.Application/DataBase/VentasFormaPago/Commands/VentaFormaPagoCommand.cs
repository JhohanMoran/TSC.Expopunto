namespace TSC.Expopunto.Application.DataBase.VentasFormaPago.Commands
{
    public record VentaFormaPagoCommand(
        int Id,
        int IdVenta,
        int IdFormaPago,
        string DescripcionFormaPago,
        decimal Monto,
        string ReferenciaPago
    );
}
