using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Application.DataBase.Perfil.Queries.Models
{
    public class PerfilesListaParametros : BaseParamsList
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
