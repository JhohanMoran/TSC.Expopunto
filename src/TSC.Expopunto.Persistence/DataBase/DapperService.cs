using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TSC.Expopunto.Application.DataBase;

namespace TSC.Expopunto.Persistence.DataBase
{
    public class DapperService:  IDapperQueryService, IDapperCommandService
    {
        private readonly string _connectionString;

        public DapperService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQLConnectionString");
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

        public async Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
