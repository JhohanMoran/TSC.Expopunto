using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Dashboard.Queries.Models
{
    public class DashboardChartsModel
    {
        public List<ChartsNumVentasModel>? ChartsNumVentas { get; set; }
        public List<ChartsMontoVentasModel>? ChartsMontoVentas { get; set; }
        public List<ChartsFormasPagoVentasModel>? ChartsFormasPagoVentas { get; set; }
        public ActividadRecienteModel? ActividadReciente { get; set; }
        public EstadisticasRapidasModel? EstadisticasRapidas { get; set; }
    }
    public class ChartsNumVentasModel
    {
        public string SemanaAnio { get; set; } = string.Empty;
        public int NumeroVentas { get; set; }
    }
    public class ChartsMontoVentasModel
    {
        public string MesAnio { get; set; } = string.Empty;
        public decimal MontoVenta { get; set; }
    }
    public class ChartsFormasPagoVentasModel
    {
        public int IdFormaPago { get; set; }
        public string DescripcionFormaPago { get; set; } = string.Empty;
        public string RutaIcono { get; set; } = string.Empty;
        public int NumVentas { get; set; }
        public decimal PorcentajeVentas { get; set; }
    }
    public class ActividadRecienteModel
    {
        public int IdVenta { get; set; }
        public string FechaVenta { get; set; } = string.Empty;
        public string NombrePersona { get; set; } = string.Empty;
        public decimal MontoVenta { get; set; }
    }
    public class EstadisticasRapidasModel
    {
        public int VentasActivas { get; set; }
        public int VentasAnuladas { get; set; }
        public int GuiasPendientesRevision { get; set; }
        public int VentasPendientesRevision { get; set; }
    }
}
