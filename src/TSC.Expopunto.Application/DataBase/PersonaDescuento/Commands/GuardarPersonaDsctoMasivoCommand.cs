using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands
{
    public record GuardarPersonaDsctoMasivoCommand
    (
        

    ) : IRequest<PersonaDescuentoDTO>;
}
