namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaAprobacionDTO : VentaDTO
    {
        public int IdDocumentoEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
        public string ColorEstado { get; set; } = string.Empty;
    }
}
