using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;
namespace TSC.Expopunto.Application.DataBase.Sede.Queries
{
    public interface ISedeQuery
    {
        Task<List<SedesTodosModel>> ListarTodosAsync(string? nombre = null);
        Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede);

    }
}
