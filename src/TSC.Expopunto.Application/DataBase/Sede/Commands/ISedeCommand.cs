using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public interface ISedeCommand
    {
        Task ProcesarAsync(SedeCompletaModel model);
        Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede);

    }
}
