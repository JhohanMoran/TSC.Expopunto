using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TSC.Expopunto.Application.DataBase
{
    public interface IDapperQueryService
    {
        void UsarConexion(string connectionName);
        Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, object parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters = null, int? timeOut = null);
        IEnumerable<T> Query<T>(string procedureName, object parameters = null);
        Task<TResult> QueryMultipleAsync<TResult>(string procedureName,Func<SqlMapper.GridReader, Task<TResult>> map, object parameters = null, int? timeOut = null);
        IDbConnection CreateConnection();
    }
}
