using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;

namespace Core.Persistance;

public class DbMigrator
{
    private readonly IMigrationRunner _runner;
    private readonly SqlConnectionFactory _factory;
    private readonly string _connectionString;

    public DbMigrator(IMigrationRunner runner, SqlConnectionFactory factory, string connectionString)
    {
        _runner = runner;
        _factory = factory;
        _connectionString = connectionString;
    }
    
    public async Task Migrate()
    {
        using var connection = new SqlConnection(MasterConnectionString());
        await connection.ExecuteAsync(@"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestNotes') CREATE DATABASE TestNotes;");
        _runner.MigrateUp();
    }

    public async Task EnsureDeleted()
    {
        using SqlConnection connection = _factory.Create();
        await connection.ExecuteAsync(@"DROP DATABASE TestNotes");
    }

    private string MasterConnectionString()
    {
        return $"Server={ExtractServer(_connectionString)};Database=master;User Id=SA;Password={ExtractPassword(_connectionString)}";
    }

    public static string ExtractServer(string connectionString)
    {
        return ExtractConnectionString(connectionString, "Server=");
    }

    public static string ExtractDatabase(string connectionString)
    {
        return ExtractConnectionString(connectionString, "Database=");
    }
    
    public static string ExtractPassword(string connectionString)
    {
        return ExtractConnectionString(connectionString, "Password=");
    }

    private static string ExtractConnectionString(string connectionString, string key)
    {
        int start = connectionString.IndexOf(key) + key.Length;
        int end = connectionString.IndexOf(";", start);

        return connectionString[start..end];
    }
}