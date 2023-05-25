using FluentMigrator;

namespace Core.Persistance.Migrations;

[Migration(1684979297)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("TestNotes")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Note").AsString();
    }

    public override void Down()
    {
        Delete.Table("TestNotes");
    }
}