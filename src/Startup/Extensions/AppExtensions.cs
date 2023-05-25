using Core.Persistance;

namespace Startup.Extensions;

public static class AppExtensions
{
    public static async Task ConfigureDb(this WebApplication app)
    {
        await app.Services.GetRequiredService<DbMigrator>().Migrate();
    }
}