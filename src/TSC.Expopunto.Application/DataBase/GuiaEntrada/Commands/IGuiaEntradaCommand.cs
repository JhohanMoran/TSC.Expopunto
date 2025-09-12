using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Sede.Commands;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands
{
    public interface IGuiaEntradaCommand
    {
        Task<GuiaEntradaModel> ProcesarAsync(GuiaEntradaModel model);
    }
}
