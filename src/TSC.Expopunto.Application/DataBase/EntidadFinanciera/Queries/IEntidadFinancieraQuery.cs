using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries
{
    public interface IEntidadFinancieraQuery
    {
        Task<List<EntidadeFinancieraTodosModel>> ListarTodosAsync();
        Task<EntidadeFinancieraTodosModel> ObtenerEntidadFinancieraPorIdAsync(int idEntidad);

    }
}
