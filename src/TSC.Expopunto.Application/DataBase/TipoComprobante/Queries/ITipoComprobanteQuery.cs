using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoComprobante.Queries
{
    public interface ITipoComprobanteQuery
    {
        Task<List<TiposComprobanteTodosModel>> ListarTodosAsync();
        Task<TiposComprobanteTodosModel> ObtenerTipoComprobantePorIdAsync(int idTipoComprobante);


    }
}
