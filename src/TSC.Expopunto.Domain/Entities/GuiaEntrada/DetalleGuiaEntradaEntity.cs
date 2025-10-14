namespace TSC.Expopunto.Domain.Entities.GuiaEntrada
{
    public class DetalleGuiaEntradaEntity
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; private set; }
        public int IdProducto { get; private set; }
        public int IdUnidadMedida { get; private set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; private set; }
        public string Caja { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
        public int? IdUsuario { get; set; }

        public DetalleGuiaEntradaEntity() { }
        public DetalleGuiaEntradaEntity(
            int id,
            int idGuiaEntrada,
            int idProducto,
            int idUnidadMedida,
            decimal cantidad,
            decimal costoUnitario,
            string caja,
            string codEstilo,
            string codPedido,
            int? idUsuario
        )
        {
            this.Id = id;
            this.IdGuiaEntrada = idGuiaEntrada;
            this.IdProducto = idProducto;
            this.IdUnidadMedida = idUnidadMedida;
            this.Cantidad = cantidad;
            this.CostoUnitario = costoUnitario;
            this.Caja = caja;
            this.CodigoEstilo = codEstilo;
            this.CodigoPedido = codPedido;
            this.IdUsuario = idUsuario;
        }

        public DetalleGuiaEntradaEntity(int id, int idGuiaEntrada)
        {
            this.Id = id;
            this.IdGuiaEntrada = idGuiaEntrada;
        }

        public void AsignarId(int id, int idGuiaEntrada)
        {
            Id = id;
            IdGuiaEntrada = idGuiaEntrada;
        }

    }
}
