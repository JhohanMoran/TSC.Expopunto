namespace TSC.Expopunto.Domain.Entities.GuiaEntrada
{
    public class GuiaEntradaEntity
    {
        public int Id { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int IdProveedor { get; set; }
        public string? TipoGuia { get; set; }
        public string? Observacion { get; set; }
        public decimal TotalCantidad { get; set; }
        public decimal TotalCosto { get; set; }
        public int IdUsuario { get; set; }



        private readonly List<DetalleGuiaEntradaEntity> _detalles = new();
        public IReadOnlyCollection<DetalleGuiaEntradaEntity> Detalles => _detalles;

        public GuiaEntradaEntity() { }

        public GuiaEntradaEntity(
            int id,
            string? serie,
            string? numero,
            string? fecha,
            string? hora,
            int idPersonaProveedor,
            string? tipoGuia,
            string? observacion,
            decimal totalCantidad,
            decimal totalCosto
        )
        {
            Id = id;
            Serie = serie;
            Numero = numero;
            Fecha = fecha;
            Hora = hora;
            IdProveedor = idPersonaProveedor;
            TipoGuia = tipoGuia;
            Observacion = observacion;
            TotalCantidad = totalCantidad;
            TotalCosto = totalCosto;
        }
        public void AgregarDetalle(
            int id,
            int idGuiaEntrada,
            int idProducto,
            int idUnidadMedida,
            int cantidad,
            decimal costoUnitario

        )
        {
            _detalles.Add(new DetalleGuiaEntradaEntity(
                id,
                idGuiaEntrada,
                idProducto,
                idUnidadMedida,
                cantidad,
                costoUnitario

            ));
        }

        public void Actualizar(
            int id,
            string? serie,
            string? numero,
            string? fecha,
            string? hora,
            int idProveedor,
            string? tipoGuia,
            string? observacion,
            List<DetalleGuiaEntradaEntity>? nuevosDetalles
        )
        {
            Id = id;
            Serie = serie;
            Numero = numero;
            Fecha = fecha;
            Hora = hora;
            IdProveedor = idProveedor;
            TipoGuia = tipoGuia;
            Observacion = observacion;


            _detalles.Clear();
            _detalles.AddRange(nuevosDetalles);
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
        public void AsignarIdDetalle(int index, int idDetalle, int idGuiaEntrada)
        {
            if (index < 0 || index >= _detalles.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _detalles[index].AsignarId(idDetalle, idGuiaEntrada);
        }

    }
}
