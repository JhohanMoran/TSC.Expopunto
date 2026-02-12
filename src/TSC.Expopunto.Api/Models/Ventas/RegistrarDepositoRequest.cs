using System;
using System.Collections.Generic;

namespace TSC.Expopunto.Api.Models.Ventas
{
    public class RegistrarDepositoRequest
    {
        public string NroOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public List<int> IdsVentas { get; set; }
    }
}