using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class AppDbContext : DbContext
{
    public TestNoteData TestNote { get; } = null!;
}