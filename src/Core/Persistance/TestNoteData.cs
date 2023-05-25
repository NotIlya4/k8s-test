namespace Core.Persistance;

public class TestNoteData
{
    public int Id { get; private set; }
    public string Note { get; private set; }

    public TestNoteData(int id, string note)
    {
        Id = id;
        Note = note;
    }

    public TestNoteData()
    {
        Note = null!;
    }
}