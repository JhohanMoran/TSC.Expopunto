using TSC.Expopunto.Common;

namespace TSC.Expopunto.Api.Models.GuiasEntrada
{
    public class CrearGuiaEntradaRequest
    {
        public OperationType Operation { get; set; }

        public int Id { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Fecha { get; set; }
        public int IdPersonaProveedor { get; set; }
        public string TipoGuia { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }

        public List<DetalleGuiaEntradaRequest> Detalles { get; set; } = new();
    }
}
