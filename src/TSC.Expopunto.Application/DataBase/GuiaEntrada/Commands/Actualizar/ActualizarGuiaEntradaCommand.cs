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
        string? Fecha,
        string? Hora,
        int IdProveedor,
        string? TipoGuia,
        string? Observacion,
        int idUsuario,
        decimal totalCantidad,
        decimal totalCosto,
        List<DetalleGuiaEntradaCommand>? Detalles


    ) : IRequest<GuiaEntradaDTO>;
}
