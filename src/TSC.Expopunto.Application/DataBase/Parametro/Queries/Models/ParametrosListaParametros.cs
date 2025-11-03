using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Parametro.Queries.Models
{
    public class ParametrosListaParametros : BaseParamsList
    {
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }

        public string? Codigo
        {
            get => ParametrosAdicionales.ContainsKey("Codigo")
                   ? ParametrosAdicionales["Codigo"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Codigo"] = value;
        }

        public string? Valor
        {
            get => ParametrosAdicionales.ContainsKey("Valor")
                   ? ParametrosAdicionales["Valor"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Valor"] = value;
        }

        public string? Descripcion
        {
            get => ParametrosAdicionales.ContainsKey("Descripcion")
                   ? ParametrosAdicionales["Descripcion"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Descripcion"] = value;
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

