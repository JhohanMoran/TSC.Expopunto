using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoMoneda.Queries
{
    public interface ITipoMonedaQuery
    {
        Task<List<TiposMonedaTodosModel>> ListarTodosAsync();
        Task<TiposMonedaTodosModel> ObtenerTipoMonedaPorIdAsync(int idTipoMoneda);
    }
}
