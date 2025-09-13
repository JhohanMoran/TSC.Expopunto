using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.Models;


namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries
{
    public interface IGuiaEntradaQuery
    {
        Task<List<GuiasEntradaTodosModel>> ListarTodosAsync();
        Task<GuiasEntradaTodosModel> ObtenerGuiaEntradaPorIdAsync(int idGuiaEntrada);
    }
}
