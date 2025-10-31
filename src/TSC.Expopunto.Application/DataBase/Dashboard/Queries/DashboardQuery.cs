using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Dashboard.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Dashboard.Queries
{
    public class DashboardQuery : IDashboardQuery
    {
        private readonly IDapperQueryService _dapperService;
        public DashboardQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<DashboardValuesTodosModel> ObtenerValoresDashboardAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<DashboardValuesTodosModel>("uspGetDashboard", parameters);
            return response;
        }

        public async Task<DashboardChartsModel> ObtenerCartsDashboardAsync()
        {
            var parameters = new
            {
                pOpcion = 2
            };
            var response = await _dapperService.QueryMultipleAsync("uspGetDashboard",
                async (multi) =>
                {
                    var charts = new DashboardChartsModel();                   
                    var numVentas = await multi.ReadAsync<ChartsNumVentasModel>();
                    var montoVentas = await multi.ReadAsync<ChartsMontoVentasModel>();
                    var personaVentas = await multi.ReadAsync<ChartsPersonaVentasModel>();
                    var actividadReciente = await multi.ReadFirstOrDefaultAsync<ActividadRecienteModel>();

                    charts.ChartsNumVentas = numVentas.ToList();
                    charts.ChartsMontoVentas = montoVentas.ToList();
                    charts.ChartsPersonaVentas = personaVentas.ToList();
                    charts.ActividadReciente = actividadReciente;

                    return charts;
                },
                parameters
                , 0);
            return response;
        }
    }
}
