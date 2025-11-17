using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class ImpresionVentaDTO
    {
        public DatosEmpresaModel Empresa { get; set; }
        public SedesTodosModel Sede { get; set; }
        public VentaDTO Venta { get; set; }
        public TiposMonedaTodosModel TipoMoneda { get; set; }
        public string qrData { get; set; }
    }
}
