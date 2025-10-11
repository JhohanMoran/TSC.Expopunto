using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands.Models;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Commands
{
    public interface IProductoVarianteCommand
    {
        Task<ProductoVarianteModel> ProcesarAsync(ProductoVarianteModel param);
    }
}
