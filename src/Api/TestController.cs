using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("test")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return Ok("Very ok!");
    }
}