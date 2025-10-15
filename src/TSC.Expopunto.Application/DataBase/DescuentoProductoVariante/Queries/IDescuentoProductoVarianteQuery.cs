using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries
{
    public interface IDescuentoProductoVarianteQuery
    {
        Task<List<DescuentoProductoVarianteModel>> ListarAsync(DescuentoProductoVarianteListaParametros parametros);
        Task<List<DescuentoProductoVarianteModel>> ListarComboAsync();
        Task<DescuentoProductoVarianteModel> ListarPorIdAsync(int id);
    }
}
