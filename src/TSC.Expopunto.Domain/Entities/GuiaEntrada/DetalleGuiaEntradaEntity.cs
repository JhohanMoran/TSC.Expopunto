namespace TSC.Expopunto.Domain.Entities.GuiaEntrada
{
    public class DetalleGuiaEntradaEntity
    {
        public int Id { get; set; }
        public int IdGuiaEntrada { get; private set; }
        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; private set; }
        public string CodUniMed { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public string NumCaja { get; set; }
        public string CodProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoEstilo { get; set; } = string.Empty;
        public string CodigoPedido { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CodigoSku { get; set; } = string.Empty;
        public string Talla { get; set; } = string.Empty;
        public int IdUsuario { get; set; }

        public DetalleGuiaEntradaEntity() { }
        public DetalleGuiaEntradaEntity(
            int id,
            int idGuiaEntrada,
            int idProducto,
            int idUnidadMedida,
            string codUniMed,
            decimal cantidad,
            string numCaja,
            string codProducto,
            string nombre,
            string codEstilo,
            string codPedido,
            int idCategoria,
            string categoria,
            string genero,
            string color,
            string codigoSku,
            string talla,
            int idUsuario
        )
        {
            this.Id = id;
            this.IdGuiaEntrada = idGuiaEntrada;
            this.IdProducto = idProducto;
            this.IdUnidadMedida = idUnidadMedida;
            this.CodUniMed = codUniMed;
            this.Cantidad = cantidad;
            this.NumCaja = numCaja;
            this.CodProducto = codProducto;
            this.Nombre = nombre;
            this.CodigoEstilo = codEstilo;
            this.CodigoPedido = codPedido;
            this.Categoria = categoria;
            this.IdCategoria = idCategoria;
            this.Genero = genero;
            this.Color = color;
            this.CodigoSku = codigoSku;
            this.Talla = talla;
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
