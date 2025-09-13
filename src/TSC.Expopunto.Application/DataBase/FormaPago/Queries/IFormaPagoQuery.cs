using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.FormaPago.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.FormaPago.Queries
{
    public interface IFormaPagoQuery
    {
        Task<List<FormasPagoTodosModel>> ListarTodosAsync();
        Task<FormasPagoTodosModel> ObtenerFormaPagoPorIdAsync(int idFormaPago);
    }
}
