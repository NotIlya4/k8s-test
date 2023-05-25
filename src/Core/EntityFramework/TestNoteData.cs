namespace Core.EntityFramework;

public class TestNoteData
{
    public string Note { get; private set; }

    public TestNoteData(string note)
    {
        Note = note;
    }

    public TestNoteData()
    {
        Note = null!;
    }
}