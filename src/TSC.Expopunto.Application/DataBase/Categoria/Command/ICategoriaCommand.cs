using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Categoria.Command
{
    public interface ICategoriaCommand
    {
        Task<CategoriaModel> ProcesarAsync(CategoriaModel model);
    }
}
