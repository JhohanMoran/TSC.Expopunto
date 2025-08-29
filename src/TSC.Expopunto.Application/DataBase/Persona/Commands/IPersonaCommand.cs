using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands
{
    public interface IPersonaCommand
    {
        Task<PersonaModel> ProcesarAsync(PersonaModel model);
    }
}
