using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;


namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public interface IDescuentoCommand
    {
        Task<DescuentoModel> ProcesarAsync(DescuentoModel model, List<DescuentoProductoVarianteModel> detalles = null);
    }
}
