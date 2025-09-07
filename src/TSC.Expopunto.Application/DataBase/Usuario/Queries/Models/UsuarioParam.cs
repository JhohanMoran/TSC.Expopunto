using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries.Models
{
    public class UsuarioParam : BaseParamsList
    {
        public int? IdUsuario { get; set; }
        public bool? Activo { get; set; }
        public string? Nombre
        {
            get => ParametrosAdicionales.ContainsKey("Nombre")
                   ? ParametrosAdicionales["Nombre"]?.ToString()
                   : null;
            set => ParametrosAdicionales["Nombre"] = value;
        }
    }
}
