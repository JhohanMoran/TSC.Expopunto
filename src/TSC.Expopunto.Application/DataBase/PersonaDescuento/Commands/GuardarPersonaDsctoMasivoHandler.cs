using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Interfaces.Repositories.PersonaDescuento;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands
{
    public class GuardarPersonaDsctoMasivoHandler : IRequestHandler<GuardarPersonaDsctoMasivoCommand, bool>
    {
        private readonly IPersonaDescuentoRepository _repository;

        public GuardarPersonaDsctoMasivoHandler(IPersonaDescuentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GuardarPersonaDsctoMasivoCommand request, CancellationToken cancellationToken)
        {
            // Validación de fechas similar a la versión individual
            if (request.FechaInicio >= request.FechaFin)
                throw new Exception("La fecha de fin debe ser mayor a la de inicio.");

            return await _repository.GuardarMasivoAsync(request);
        }
    }
}
