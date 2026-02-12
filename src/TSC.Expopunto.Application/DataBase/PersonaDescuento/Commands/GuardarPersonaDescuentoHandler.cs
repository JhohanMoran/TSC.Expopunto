using MediatR;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento;
using TSC.Expopunto.Domain.Entities.PersonaDescuento;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands
{
    public class GuardarPersonaDescuentoHandler : IRequestHandler<GuardarPersonaDescuentoCommand, PersonaDescuentoDTO>
    {
        private readonly IPersonaDescuentoRepository _repository;
        public GuardarPersonaDescuentoHandler(IPersonaDescuentoRepository repository)
        {
            _repository = repository;   
        }

        public async Task<PersonaDescuentoDTO> Handle(GuardarPersonaDescuentoCommand request, CancellationToken cancellationToken)
        {

            if (request.FechaInicio == null || request.FechaFin == null)
            {
                throw new Exception("Debe seleccionar una fecha de inicio y fin para aplicar el descuento");
            }

            var paremetro = new PersonaDescuentoEntity()
            {
                Id = request.Id ?? 0,
                IdPersona = request.IdPersona ?? 0,
                FechaInicio = request.FechaInicio.Value,
                FechaFin = request.FechaFin.Value,
                ValorDescuento = request.ValorDescuento ?? 0,
                IdUsuario = request.IdUsuario ?? 0
            };

            var respuesta = await _repository.ProcesarAsync(paremetro);

            if (respuesta == null || respuesta.Id == 0)
            {
                throw new Exception("No se pudo registrar el Descuento para la Persona");
            }

            return new PersonaDescuentoDTO
            {
                Id = respuesta.Id,
                IdPersona = respuesta.IdPersona,
                FechaInicio = respuesta.FechaInicio,
                FechaFin = respuesta.FechaFin,
                ValorDescuento = respuesta.ValorDescuento
            };
        }
    }
}
