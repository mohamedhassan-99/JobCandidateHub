using Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var optionBuilder = new DbContextOptionsBuilder();

        optionBuilder.UseSqlServer(_connectionString);
        
        var connection = new DbContext(optionBuilder.Options);

        return connection.Database.GetDbConnection();
    }
}
