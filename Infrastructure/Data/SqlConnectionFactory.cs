using Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Data;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
