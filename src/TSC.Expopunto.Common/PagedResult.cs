namespace TSC.Expopunto.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int FilasPorPagina { get; set; }
    }
}
