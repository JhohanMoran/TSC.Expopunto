using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Models.GuiasEntrada
{
    public class ActualizarGuiaEntradaRequest
    {
        public OperationType Operation { get; set; }

        public int Id { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPersonaProveedor { get; set; }
        public string TipoGuia { get; set; }
        public string Observacion { get; set; }


        public List<DetalleGuiaEntradaRequest> Detalles { get; set; } = new();
    }
}
