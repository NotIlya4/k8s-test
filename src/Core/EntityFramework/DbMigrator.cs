using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class DbMigrator
{
    private readonly AppDbContext _dbContext;
    
    public DbMigrator(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Migrate()
    {
        await _dbContext.Database.MigrateAsync();
    }
}