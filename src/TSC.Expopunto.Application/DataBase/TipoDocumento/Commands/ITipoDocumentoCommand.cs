using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.TiposDocumento.Commands
{
    internal interface ITipoDocumentoCommand
    {
        Task<TipoDocumentoModel> ProcesarAsync(TipoDocumentoModel model);
    }
}
