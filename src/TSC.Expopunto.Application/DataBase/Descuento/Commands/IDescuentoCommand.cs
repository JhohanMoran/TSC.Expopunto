using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public interface IDescuentoCommand
    {
        Task<DescuentoModel> ProcesarAsync(DescuentoModel model);
    }
}
