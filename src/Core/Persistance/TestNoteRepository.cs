using Core.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Core.Persistance;

public class TestNoteRepository
{
    private readonly SqlConnectionFactory _factory;
    private readonly DataMapper _mapper;

    public TestNoteRepository(SqlConnectionFactory factory, DataMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
    }
    
    public async Task Add(TestNote testNote)
    {
        using SqlConnection db = _factory.Create();

        await db.ExecuteAsync(@"INSERT INTO TestNotes (Note) VALUES(@Note)", new { Note = testNote.Note });
    }

    public async Task<List<TestNote>> Get()
    {
        using SqlConnection db = _factory.Create();

        IEnumerable<TestNoteData> result = await db.QueryAsync<TestNoteData>(@"SELECT * FROM TestNotes");
        return _mapper.MapTestNotes(result.ToList());
    }
}