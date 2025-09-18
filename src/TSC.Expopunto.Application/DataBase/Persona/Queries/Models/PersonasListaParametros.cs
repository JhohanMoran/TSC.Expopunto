using TSC.Expopunto.Application.Features;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class PersonasListaParametros : BaseParamsList
    {
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }

        public string? CodTipoPersona
        {
            get => ParametrosAdicionales.ContainsKey("CodTipoPersona")
                   ? ParametrosAdicionales["CodTipoPersona"]?.ToString()
                   : null;
            set => ParametrosAdicionales["CodTipoPersona"] = value;
        }

        public int? IdTipoDocumento
        {
            get => ParametrosAdicionales.ContainsKey("IdTipoDocumento")
                   ? ParametrosAdicionales["IdTipoDocumento"] as int?
                   : null;
            set => ParametrosAdicionales["IdTipoDocumento"] = value;
        }

        public string? NumeroDocumento
        {
            get => ParametrosAdicionales.ContainsKey("NumeroDocumento")
                   ? ParametrosAdicionales["NumeroDocumento"]?.ToString()
                   : null;
            set => ParametrosAdicionales["NumeroDocumento"] = value;
        }

        public bool? Activo
        {
            get => ParametrosAdicionales.ContainsKey("Activo")
                   ? ParametrosAdicionales["Activo"] as bool?
                   : null;
            set => ParametrosAdicionales["Activo"] = value;
        }
    }
}

