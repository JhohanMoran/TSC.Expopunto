namespace TSC.Expopunto.Application.DataBase.LineaCredito.Commands
{
    public class LineaCreditoModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoConsumido { get; set; }
        public int IdUsuario { get; set; }
    }
}
