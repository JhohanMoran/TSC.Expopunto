using MediatR;
using TSC.Expopunto.Application.DataBase.Persona.DTO;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands.RegistrarPersona
{
    public record RegistrarPersonaCommand (
        int? Opcion,
        int? Id,
        string? CodTipoPersona,
        int? IdTipoDocumento,
        string? NumeroDocumento,
        string? RazonSocial,
        string? Nombres,
        string? Apellidos,
        string? Direccion,
        string? Celular,
        int? IdUsuario,
        bool? Activo,
        string? DetalleMotivoBaja

    ) : IRequest<PersonaDTO>;
}
