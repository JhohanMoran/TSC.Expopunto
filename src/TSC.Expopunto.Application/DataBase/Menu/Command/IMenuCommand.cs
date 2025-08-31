using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Menu.Command
{
    public interface IMenuCommand
    {
        Task<MenuModel> ProcesarAsync(MenuModel model);
    }
}
