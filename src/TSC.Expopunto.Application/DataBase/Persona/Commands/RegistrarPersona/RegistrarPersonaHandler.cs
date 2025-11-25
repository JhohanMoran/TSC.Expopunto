using MediatR;
using TSC.Expopunto.Application.DataBase.Persona.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Persona;
using TSC.Expopunto.Domain.Entities.Persona;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands.RegistrarPersona
{
    public class RegistrarPersonaHandler : IRequestHandler<RegistrarPersonaCommand, PersonaDTO>
    {
        private readonly IPersonaRepository _repository;
        public RegistrarPersonaHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonaDTO> Handle(RegistrarPersonaCommand request, CancellationToken cancellationToken)
        {
            PersonaEntity persona = new PersonaEntity();

            persona = new PersonaEntity(
                request.Opcion,
                request.Id,
                request.CodTipoPersona,
                request.IdTipoDocumento,
                request.NumeroDocumento,
                request.RazonSocial,
                request.Nombres,
                request.Apellidos,
                request.Direccion,
                request.Celular,
                request.IdUsuario,
                request.Activo,
                request.DetalleMotivoBaja
            );

            PersonaEntity personaRespuesta = await _repository.ProcesarAsync(persona);

            return new PersonaDTO
            {
                Opcion = personaRespuesta.Opcion,
                Id = personaRespuesta.Id,
                CodTipoPersona = personaRespuesta.CodTipoPersona,
                IdTipoDocumento = personaRespuesta.IdTipoDocumento,
                NumeroDocumento = personaRespuesta.NumeroDocumento,
                RazonSocial = personaRespuesta.RazonSocial,
                Nombres = personaRespuesta.Nombres,
                Apellidos = personaRespuesta.Apellidos,
                Direccion = personaRespuesta.Direccion,
                Celular = personaRespuesta.Celular,
                IdUsuario = personaRespuesta.IdUsuario,
                Activo = personaRespuesta.Activo,
                DetalleMotivoBaja = personaRespuesta.DetalleMotivoBaja
            };
        }
    }
}
