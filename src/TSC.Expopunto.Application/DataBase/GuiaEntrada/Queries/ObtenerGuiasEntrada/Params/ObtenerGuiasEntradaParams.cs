using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params
{
    public class ObtenerGuiasEntradaParams : BaseParamsList
    {
        public string? Serie { get; set; }
        public string? Numero { get; set; }
    }
}
