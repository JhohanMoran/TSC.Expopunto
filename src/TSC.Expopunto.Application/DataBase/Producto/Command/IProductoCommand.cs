using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Producto.Command
{
    public interface IProductoCommand
    {
        Task<ProductoModel> ProcesarAsync(ProductoModel model);
    }
}
