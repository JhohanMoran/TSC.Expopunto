using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Application.DataBase.SedeSerie.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Queries
{
    public interface ISedeSerieQuery
    {
        Task<List<SedeSerieTodosModel>> ListarAsync(int? idSede = null);
        Task<SedeSerieTodosModel> ObtenerPorIdAsync(int id);
        Task<List<SedeSerieTodosModel>> ListarTodosAsync();
        Task<List<SedeSerieTodosModel>> ListarSeriesPorSedeTipoComprobanteAsync(int idSede, int idTipoComprobante);
    }
}
