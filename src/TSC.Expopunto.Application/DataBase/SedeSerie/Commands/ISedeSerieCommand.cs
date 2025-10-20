using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Commands
{
    public interface ISedeSerieCommand
    {
        Task<SedeSerieModel> ProcesarAsync(SedeSerieModel model);
    }
}

