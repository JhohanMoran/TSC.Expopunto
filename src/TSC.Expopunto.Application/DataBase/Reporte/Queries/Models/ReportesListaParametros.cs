using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Reporte.Queries.Models
{
    public class ReportesListaParametros : BaseParamsList
    {
        public DateTime? FechaInicio
        {
            get => ParametrosAdicionales.ContainsKey("FechaInicio")
                   ? ParametrosAdicionales["FechaInicio"] as DateTime?
                   : null;
            set => ParametrosAdicionales["FechaInicio"] = value;
        }

        public DateTime? FechaFin
        {
            get => ParametrosAdicionales.ContainsKey("FechaFin")
                   ? ParametrosAdicionales["FechaFin"] as DateTime?
                   : null;
            set => ParametrosAdicionales["FechaFin"] = value;
        }

        public int? IdPersona
        {
            get => ParametrosAdicionales.ContainsKey("IdPersona")
                   ? ParametrosAdicionales["IdPersona"] as int?
                   : null;
            set => ParametrosAdicionales["IdPersona"] = value;
        }

        public int? IdTipoComprobante
        {
            get => ParametrosAdicionales.ContainsKey("IdTipoComprobante")
                   ? ParametrosAdicionales["IdTipoComprobante"] as int?
                   : null;
            set => ParametrosAdicionales["IdTipoComprobante"] = value;
        }

        public string? Serie
        {
            get => ParametrosAdicionales.ContainsKey("Serie")
                   ? ParametrosAdicionales["Serie"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Serie"] = value;
        }

        public string? Numero
        {
            get => ParametrosAdicionales.ContainsKey("Numero")
                   ? ParametrosAdicionales["Numero"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Numero"] = value;
        }
    }
}
