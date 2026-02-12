using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands
{
    public record GuardarPersonaDescuentoCommand
    (
        int? Id,
        int? IdPersona,
        DateTime? FechaInicio,
        DateTime? FechaFin,
        decimal? ValorDescuento,
        int? IdUsuario

    ) : IRequest<PersonaDescuentoDTO>;
}
