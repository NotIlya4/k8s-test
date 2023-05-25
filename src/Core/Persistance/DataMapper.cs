using Core.Models;

namespace Core.Persistance;

public class DataMapper
{
    public TestNote MapTestNote(TestNoteData data)
    {
        return new TestNote(data.Note);
    }

    public List<TestNote> MapTestNotes(List<TestNoteData> datas)
    {
        return datas.Select(MapTestNote).ToList();
    }
}