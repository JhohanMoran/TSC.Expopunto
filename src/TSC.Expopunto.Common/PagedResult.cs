namespace TSC.Expopunto.Common
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new();
        public int Total { get; set; }
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
        public int TotalPaginas { get; set; }
    }
}
