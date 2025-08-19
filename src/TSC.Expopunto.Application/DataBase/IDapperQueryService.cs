namespace TSC.Expopunto.Application.DataBase
{
    public interface IDapperQueryService
    {
        Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, object parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters = null);
    }
}
