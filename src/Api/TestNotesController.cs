using Core.Models;
using Core.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("testNotes")]
[ApiController]
public class TestNotesController : ControllerBase
{
    private readonly TestNoteRepository _repository;

    public TestNotesController(TestNoteRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    public async Task<ActionResult> Add(string note)
    {
        await _repository.Add(new TestNote(note));
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> Get()
    {
        return Ok((await _repository.Get()).Select(n => n.Note).ToList());
    }
}