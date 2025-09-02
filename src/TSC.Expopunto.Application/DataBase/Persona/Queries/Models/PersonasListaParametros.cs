using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class PersonasListaParametros:BaseParamsList
    {
        public string Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }
    }
}
