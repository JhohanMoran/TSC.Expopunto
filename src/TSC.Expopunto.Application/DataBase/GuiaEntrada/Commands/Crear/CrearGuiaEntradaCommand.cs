using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear
{
    public record CrearGuiaEntradaCommand
    (
        OperationType Operation,

        int Id,
        string? Serie,
        string? Numero,
        string? Fecha,
        int idPersonaProveedor,
        string? TipoGuia,
        string? Observacion,

        List<DetalleGuiaEntradaCommand>? Detalles

        ) : IRequest<GuiaEntradaDTO>
    {
        public int IdPersonaProveedor { get; internal set; }
    }
}
