﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TSC.Expopunto.Application.DataBase;

namespace TSC.Expopunto.Infrastructure.DataBase
{
    public class DapperCommandService : IDapperCommandService
    {
        private readonly string _connectionString;

        public DapperCommandService(IConfiguration configuration)
        {
            // Usa el nombre de tu cadena de conexión en appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> ExecuteScalarAsync(string procedureName, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
