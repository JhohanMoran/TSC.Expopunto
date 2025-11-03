using System.Data;

namespace TSC.Expopunto.Application.DataBase
{
    public interface IDapperCommandService
    {
        Task<int> ExecuteScalarAsync(string procedureName, object parameters);
        Task<T> QueryFirstOrDefaultAsync<T>(string v, object parameters);
        Task ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
