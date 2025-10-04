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
        public DateTime? FechaFin
        {
            get
            {
                if (ParametrosAdicionales.ContainsKey("FechaFin") && ParametrosAdicionales["FechaFin"] != null)
                {
                    if (ParametrosAdicionales["FechaFin"] is DateTime dt) return dt;
                    if (DateTime.TryParse(ParametrosAdicionales["FechaFin"].ToString(), out var parsed)) return parsed;
                }
                return null;
            }
            set => ParametrosAdicionales["FechaFin"] = value;
        }

        public DateTime? FechaInicio
        {
            get
            {
                if (ParametrosAdicionales.ContainsKey("FechaInicio") && ParametrosAdicionales["FechaInicio"] != null)
                {
                    if (ParametrosAdicionales["FechaInicio"] is DateTime dt) return dt;
                    if (DateTime.TryParse(ParametrosAdicionales["FechaInicio"].ToString(), out var parsed)) return parsed;
                }
                return null;
            }
            set => ParametrosAdicionales["FechaInicio"] = value;
        }

        public int? IdPersona
        {
            get => ParametrosAdicionales.ContainsKey("IdPersona")
                   ? ParametrosAdicionales["IdPersona"] as int?
                   : null;
            set => ParametrosAdicionales["IdPersona"] = value;
        }

        public string? Sede
        {
            get => ParametrosAdicionales.ContainsKey("Sede")
                   ? ParametrosAdicionales["Sede"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Sede"] = value;
        }

        public string? TipoComprobante
        {
            get => ParametrosAdicionales.ContainsKey("TipoComprobante")
                   ? ParametrosAdicionales["TipoComprobante"]?.ToString()
                   : null;
            set => ParametrosAdicionales["TipoComprobante"] = value;
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
