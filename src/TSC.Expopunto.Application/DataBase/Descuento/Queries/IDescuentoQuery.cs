using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Descuento.Queries.Models;
using TSC.Expopunto.Domain.Models;

namespace TSC.Expopunto.Application.DataBase.Descuento.Queries
{
    public interface IDescuentoQuery
    {

        Task<List<DescuentosTodosModel>> ListarDescuentosAsync(DescuentosListaParametros baseParamsList);
        Task<List<DescuentosTodosModel>> ListarDescuentosPorEstadoAsync(bool? activo);
        Task<List<DescuentosTodosModel>> ListarComboDescuentosAsync();
        Task<DescuentosTodosModel> ListarDescuentosPorIdAsync(int idDescuento);

    }
}
