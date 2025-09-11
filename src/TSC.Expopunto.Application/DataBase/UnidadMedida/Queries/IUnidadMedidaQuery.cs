using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.UnidadMedida.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.UnidadMedida.Queries
{
    public interface IUnidadMedidaQuery
    {
      Task<List<UnidadesMedidaTodosModel>> ListarTodosAsync();
      Task<UnidadesMedidaTodosModel> ObtenerUnidadMedidaPorIdAsync(int idUnidadMedida);
    }
}
