using Microsoft.AspNetCore.Mvc;

namespace HomeworkOne.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActionResultsDemonstrationController : ControllerBase
{
    [HttpGet("ok")]
    public IActionResult GetOk()
    {
        return Ok(new { message = "Success!", data = "Demonstrating Ok Action Result" });
    }
    
    [HttpGet("not-found")]
    public IActionResult GetNotFound()
    {
        return NotFound(new { message = "Not found" });
    }

    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new { message = "This is a bad request" });
    }

    [HttpPost("created")]
    public IActionResult PostCreated()
    {
        var resourceUrl = Url.Action("GetOk");
        return Created(resourceUrl, new { message = "Resource created successfully" });
    }

    [HttpGet("server-error")]
    public IActionResult GetInternalServerError()
    {
        return StatusCode(500, new { message = "Internal Server Error occurred" });
    }
}