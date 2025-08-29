using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public interface ISedeCommand
    {
        Task<SedeModel>ProcesarAsync(SedeModel model);
    }
}
