using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.AnularVenta
{
    public record AnularVentaCommand
    (
        int? IdVenta,
        int? IdMotivoBaja,
        string? Observacion,
        int? IdUsuario
    ) : IRequest<DocumentoEstadoDTO?>;
}
