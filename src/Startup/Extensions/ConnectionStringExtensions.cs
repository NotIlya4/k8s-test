using System.Text;

namespace Startup.Extensions;

public static class ConnectionStringExtensions
{
    public static string GetSqlServerConnectionString(this IConfiguration config, string? key = null)
    {
        if (key is not null)
        {
            config = config.GetSection(key);
        }

        string server = config.GetRequiredValue("Server");
        string database = config.GetRequiredValue("Database");
        string userId = config.GetRequiredValue("User Id");
        string password = config.GetRequiredValue("Password");
        string? multipleActiveResultSets = config["MultipleActiveResultSets"];
        string? trustServerCertificate = config["TrustServerCertificate"];

        StringBuilder connectionString =
            new StringBuilder($"Server={server};Database={database};User Id={userId};Password={password};");

        if (multipleActiveResultSets is not null)
        {
            connectionString.Append($";MultipleActiveResultSets={multipleActiveResultSets}");
        }

        if (trustServerCertificate is not null)
        {
            connectionString.Append($";TrustServerCertificate={trustServerCertificate}");
        }

        return connectionString.ToString();
    }
}