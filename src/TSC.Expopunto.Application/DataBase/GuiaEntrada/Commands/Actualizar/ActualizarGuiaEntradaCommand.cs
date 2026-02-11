using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar
{
    public record ActualizarGuiaEntradaCommand
    (
        OperationType Operation,

        int Id,
        string? Serie,
        string? Numero,
        DateTime Fecha,
        TimeSpan Hora,
        int IdProveedor,
        string? TipoGuia,
        string? Observacion,
        decimal TotalCantidad,
        decimal TotalCosto,
        int IdUsuario,
        List<DetalleGuiaEntradaCommand>? Detalles


    ) : IRequest<GuiaEntradaDTO>;
}
