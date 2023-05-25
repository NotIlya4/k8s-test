using Core.Persistance;
using Core.Persistance.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class DiExtensions
{
    public static void AddAll(this IServiceCollection services, string mssqlConnectionString)
    {
        services.AddRepositories(mssqlConnectionString);
        services.AddMigrator(mssqlConnectionString);
    }
    
    public static void AddRepositories(this IServiceCollection services, string mssqlConnectionString)
    {
        services.AddScoped<DataMapper>();
        services.AddScoped(_ => new SqlConnectionFactory(mssqlConnectionString));
        services.AddScoped<TestNoteRepository>();
    }

    public static void AddMigrator(this IServiceCollection services, string mssqlConnectionString)
    {
        services.AddTransient<DbMigrator>(serviceProvider => 
            new DbMigrator(
                serviceProvider.GetRequiredService<IMigrationRunner>(),
                serviceProvider.GetRequiredService<SqlConnectionFactory>(),
                mssqlConnectionString));
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(mssqlConnectionString)
                .ScanIn(typeof(InitialMigration).Assembly).For.Migrations());
    }
}