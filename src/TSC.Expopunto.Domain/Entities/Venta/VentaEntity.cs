

namespace TSC.Expopunto.Domain.Entities.Venta
{
    public class VentaEntity
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public int? IdSede { get; set; }
        public string? Sede { get; set; }
        public int? IdTipoComprobante { get; set; }
        public string? TipoComprobante { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public int? IdPersona { get; set; }
        public string? NombrePersona { get; set; }
        public string? DocumentoPersona { get; set; }
        public int? IdTipoMoneda { get; set; }
        public string? SimboloDocumento { get; set; }
        public int? IdUsuarioVendedor { get; set; }
        public string? NombreVendedor { get; set; }
        
        public decimal? DescuentoTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }

        public int? IdUsuario { get; set; }
        public bool? Activo { get; set; }

        private readonly List<DetalleVentaEntity> _detalles = new();
        public IReadOnlyCollection<DetalleVentaEntity> Detalles => _detalles;

        private readonly List<VentaFormasPagoEntity> _formasPago = new();
        public IReadOnlyCollection<VentaFormasPagoEntity> FormasPago => _formasPago;


        public VentaEntity() { }

        public VentaEntity(
            int id,
            DateTime? fecha,
            string? hora,
            int? idSede,
            int? idTipoComprobante,
            string? serie,
            string? numero,
            int? idPersona,
            int? idTipoMoneda,
            int? idUsuarioVendedor,
            decimal? descuentoTotal,
            decimal? subTotal,
            decimal? impuesto,
            decimal? total,
            int? idUsuario,
            bool? activo
        )
        {
            Id = id;
            Fecha = fecha;
            Hora = hora;
            IdSede = idSede;
            IdTipoComprobante = idTipoComprobante;
            Serie = serie;
            Numero = numero;
            IdPersona = idPersona;
            IdTipoMoneda = idTipoMoneda;
            IdUsuarioVendedor = idUsuarioVendedor;
            DescuentoTotal = descuentoTotal;
            SubTotal = subTotal;
            Impuesto = impuesto;
            Total = total;
            IdUsuario = idUsuario;
            Activo = activo;
        }

        public void AsignarId(int id)
        {
            Id = id;
        }

        public void AgregarDetalle(
            int id,
            int idVenta,
            int idProductoVariante,
            int idTipoOperacion,
            int codigoTipoOperacion, 
            string descripcion,
            int cantidad,
            decimal precioUnitario,
            bool aplicaICBP,    
            int idDescuento,
            decimal valorDescuento, 
            decimal subTotal,
            bool activo
        )
        {
            _detalles.Add(new DetalleVentaEntity(
                id,
                idVenta,
                idProductoVariante,
                idTipoOperacion,
                codigoTipoOperacion,
                descripcion,
                cantidad,
                precioUnitario,
                aplicaICBP,
                idDescuento,
                valorDescuento,
                subTotal,
                activo
            ));
        }

        public void AgregarFormaPago(
            int id,
            int idVenta,
            int idFormaPago,
            decimal monto,
            string referenciaPago,
            string rutaIcono    
       )
        {
            _formasPago.Add(new VentaFormasPagoEntity(
                id,
                idVenta,
                idFormaPago,
                monto,
                referenciaPago,
                rutaIcono
            ));
        }

        public void Actualizar(
            int id,
            DateTime? fecha,
            string? hora,
            int? idSede,
            int? idTipoComprobante,
            string? serie,
            string? numero,
            int? idPersona,
            int? idTipoMoneda,
            int? idUsuarioVendedor,
            decimal? descuentoTotal,
            decimal? subTotal,
            decimal? impuesto,
            decimal? total,
            int? idUsuario,
            bool? activo,
            List<DetalleVentaEntity>? nuevosDetalles,
            List<VentaFormasPagoEntity>? nuevasFormasPago
        )
        {
            Id = id;
            Fecha = fecha;
            Hora = hora;
            IdSede = idSede;
            IdTipoComprobante = idTipoComprobante;
            Serie = serie;
            Numero = numero;
            IdPersona = idPersona;
            IdTipoMoneda = idTipoMoneda;
            IdUsuarioVendedor = idUsuarioVendedor;
            IdUsuario = idUsuario;
            Activo = activo;

            _detalles.Clear();
            _detalles.AddRange(nuevosDetalles);

            _formasPago.Clear();
            _formasPago.AddRange(nuevasFormasPago);
        }


        public void AsignarIdDetalle(int index, int idDetalle, int idVenta)
        {
            if (index < 0 || index >= _detalles.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _detalles[index].AsignarId(idDetalle, idVenta);
        }

        public void AsignarIdVentaFormaPago(int index, int idVentaFormaPago, int idVenta)
        {
            if (index < 0 || index >= _formasPago.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _formasPago[index].AsignarId(idVentaFormaPago, idVenta);
        }
    }
}
