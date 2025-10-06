using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TSC.Expopunto.Application.DataBase;

namespace TSC.Expopunto.Persistence.DataBase
{
    public class DapperService : IDapperQueryService, IDapperCommandService
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;

        public DapperService(IConfiguration IConfiguration)
        {
            _configuration = IConfiguration;
            _connectionString = _configuration.GetConnectionString("SQLConnectionString");
        }

        public void UsarConexion(string connectionName)
        {
            _connectionString = _configuration.GetConnectionString(connectionName);
        }

        public async Task<int> ExecuteScalarAsync(string procedureName, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, object parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters = null, int? timeOut = null)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: timeOut);
        }

        public IEnumerable<T> Query<T>(string procedureName, object parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<TResult> QueryMultipleAsync<TResult>(string procedureName, Func<SqlMapper.GridReader, Task<TResult>> map, object parameters = null, int? timeOut = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var gridReader = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: timeOut);
            return await map(gridReader);
        }
    }
}
