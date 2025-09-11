namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class VentaEntity
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTipoComprobante { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public int? IdPersonaCliente { get; set; }
        public int? IdTipoMoneda { get; set; }
        public int? IdUsuarioVendedor { get; set; }
        public int? IdUsuario { get; set; }

        private readonly List<DetalleVentaEntity> _detalles = new();
        public IReadOnlyCollection<DetalleVentaEntity> Detalles => _detalles;

        public VentaEntity() { }

        public VentaEntity(
            int id,
            DateTime? fecha,    
            int? idTipoComprobante,
            string? serie,
            string? numero,
            int? idPersonaCliente,
            int? idTipoMoneda,
            int? idUsuarioVendedor,
            int? idUsuario
        )
        {
            Id = id;
            Fecha = fecha;
            IdTipoComprobante = idTipoComprobante;
            Serie = serie;
            Numero = numero;
            IdPersonaCliente = idPersonaCliente;
            IdTipoMoneda = idTipoMoneda;
            IdUsuarioVendedor = idUsuarioVendedor;
            IdUsuario = idUsuario;
        }

        public void AgregarDetalle(
            int id,
            int idVenta,
            int idProducto,
            int idTalla,
            int cantidad,
            decimal precioUnitario
        )
        {
            _detalles.Add(new DetalleVentaEntity(
                id,
                idVenta,
                idProducto,
                idTalla,
                cantidad,
                precioUnitario
            ));
        }

        public void Actualizar(
            int id,
            DateTime? fecha,
            int? idTipoComprobante,
            string? serie,
            string? numero,
            int? idPersonaCliente,
            int? idTipoMoneda,
            int? idUsuarioVendedor,
            int? idUsuario,
            List<DetalleVentaEntity>? nuevosDetalles   
        )
        {
            Id = id;
            Fecha = fecha;
            IdTipoComprobante = idTipoComprobante;
            Serie = serie;
            Numero = numero;
            IdPersonaCliente = idPersonaCliente;
            IdTipoMoneda = idTipoMoneda;
            IdUsuarioVendedor = idUsuarioVendedor;
            IdUsuario = idUsuario;

            _detalles.Clear();
            _detalles.AddRange(nuevosDetalles);   
        }

    }
}
