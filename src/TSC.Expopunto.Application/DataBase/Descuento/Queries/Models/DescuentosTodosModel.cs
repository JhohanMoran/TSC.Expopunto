namespace TSC.Expopunto.Application.DataBase.Descuento.Queries.Models
{
    public class DescuentosTodosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string ValorDisplay { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public string FechaInicioDisplay { get; set; }
        public string FechaFinDisplay { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
        public int TotalRegistros { get; set; }
        public int? IdDetalle { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }

        public bool ActivoDetalle { get; set; }

        public int IdProductoVariante { get; set; }

        public List<DescuentosTodosModel> Detalles { get; set; } = new List<DescuentosTodosModel>();

    }
}
