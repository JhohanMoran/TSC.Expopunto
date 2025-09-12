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
        public bool? Activo { get; set; }

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
            int? idUsuario,
            bool? activo
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
            Activo = activo;
        }

        public void AgregarDetalle(
            int id,
            int idVenta,
            int idProducto,
            int idTalla,
            int cantidad,
            decimal precioUnitario,
            bool activo
        )
        {
            _detalles.Add(new DetalleVentaEntity(
                id,
                idVenta,
                idProducto,
                idTalla,
                cantidad,
                precioUnitario,
                activo
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
            bool? activo,   
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
            Activo = activo;

            _detalles.Clear();
            _detalles.AddRange(nuevosDetalles);   
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
        public void AsignarIdDetalle(int index, int idDetalle, int idVenta)
        {
            if (index < 0 || index >= _detalles.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _detalles[index].AsignarId(idDetalle, idVenta);
        }

      
    }
}
