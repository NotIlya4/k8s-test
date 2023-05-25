using Core.Persistance;

namespace UnitTests;

public class DbMigratorTests
{
    private readonly string _connectionString = @"Server=localhost,1433;Database=TestNotes;User Id=SA;Password=1tsJusT@S@mpleP@ssword!;";

    [Fact]
    public void ExtractServer_NormalConnectionString_Localhost1433()
    {
        string expect = "localhost,1433";

        string result = DbMigrator.ExtractServer(_connectionString);
        
        Assert.Equal(expect, result);
    }
    
    [Fact]
    public void ExtractDatabase_NormalConnectionString_TestNotes()
    {
        string expect = "TestNotes";

        string result = DbMigrator.ExtractDatabase(_connectionString);
        
        Assert.Equal(expect, result);
    }
    
    [Fact]
    public void ExtractPassword_NormalConnectionString_Password()
    {
        string expect = "1tsJusT@S@mpleP@ssword!";

        string result = DbMigrator.ExtractPassword(_connectionString);
        
        Assert.Equal(expect, result);
    }
}