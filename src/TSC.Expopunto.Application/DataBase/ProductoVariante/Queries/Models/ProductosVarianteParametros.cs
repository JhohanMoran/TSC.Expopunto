using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Queries.Models
{
    public class ProductosVarianteParametros : BaseParamsList
    {
        public string Filtro
        {
            get => ParametrosAdicionales.ContainsKey("Filtro")
                   ? ParametrosAdicionales["Filtro"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Filtro"] = value;
        }
    }
}
