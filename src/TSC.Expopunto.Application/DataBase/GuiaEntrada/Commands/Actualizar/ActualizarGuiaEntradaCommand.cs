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
        int IdPersonaProveedor,
        string? TipoGuia,
        string? Observacion,


         List<DetalleGuiaEntradaCommand>? Detalles


    ) : IRequest<GuiaEntradaDTO>;
}
