namespace TSC.Expopunto.Application.DataBase
{
    public interface IDapperCommandService
    {
        Task<int> ExecuteScalarAsync(string procedureName, object parameters);
    }
}
