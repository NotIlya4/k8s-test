namespace Core.Models;

public record TestNote
{
    public string Note { get; }

    public TestNote(string note)
    {
        Note = note;
    }
}