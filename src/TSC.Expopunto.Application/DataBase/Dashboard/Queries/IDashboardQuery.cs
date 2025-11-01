using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Dashboard.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Dashboard.Queries
{
    public interface IDashboardQuery
    {
        Task<DashboardValuesTodosModel> ObtenerValoresDashboardAsync();
        Task<DashboardChartsModel> ObtenerCartsDashboardAsync();
    }
}
