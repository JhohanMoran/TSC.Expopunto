using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Commands
{
    public interface IUsuariosSedeCommand
    {
        Task ProcesarAsync(UsuariosSedeModel model);
    }
}
