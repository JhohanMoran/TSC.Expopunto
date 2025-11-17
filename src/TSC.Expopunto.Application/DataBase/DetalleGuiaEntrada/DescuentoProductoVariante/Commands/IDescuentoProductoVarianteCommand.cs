using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands
{
    public interface IDescuentoProductoVarianteCommand
    {
        Task<DescuentoProductoVarianteModel> ProcesarAsync(DescuentoProductoVarianteModel model);
    }
}
