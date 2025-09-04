using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.MedioPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.MedioPago.Queries
{
    public interface IMedioPagoQuery
    {
        Task<List<MediosPagoTodosModel>> ListarTodosAsync();
        Task<MediosPagoTodosModel> ObtenerMedioPagoPorIdAsync(int idMedioPago);
    }
}
