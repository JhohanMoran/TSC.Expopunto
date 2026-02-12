namespace TSC.Expopunto.Application.DataBase.Venta.DTO
{
    public class VentaDepositoDTO
    {
        public int Id { get; set; }
        public int IdDeposito { get; set; }
        public string Serie { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NombrePersona { get; set; } = string.Empty;
        public string NombreEstado { get; set; } = string.Empty;
        public string ColorEstadoBase { get; set; } = string.Empty;
        public string CodigoEstadoBase { get; set; } = string.Empty;
        public string FechaRegistroDisplay { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string NroOperacion { get; set; } = string.Empty;
        public string NombreCompletoUsuario { get; set; } = string.Empty;

        public decimal ImporteTotal { get; set; }
        public string SimboloMoneda { get; set; } = "S/";
    }
}