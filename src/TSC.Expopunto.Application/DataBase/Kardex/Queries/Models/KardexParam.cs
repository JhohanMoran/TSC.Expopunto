using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Kardex.Queries.Models
{
    public class KardexParam : BaseParamsList
    {
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }
    }
}
