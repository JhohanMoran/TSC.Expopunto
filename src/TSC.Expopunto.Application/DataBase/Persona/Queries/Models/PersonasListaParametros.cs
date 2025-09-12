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

        public bool? Activo
        {
            get => ParametrosAdicionales.ContainsKey("Activo")
                   ? ParametrosAdicionales["Activo"] as bool?
                   : null;
            set => ParametrosAdicionales["Activo"] = value;
        }
    }
}

