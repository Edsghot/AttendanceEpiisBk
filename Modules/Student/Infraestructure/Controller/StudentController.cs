using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Event.Application.Port;

namespace AttendanceEpiisBk.Modules.Student.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IEventInputPort _eventInputPort;
    private readonly IEventOutPort _eventOutPort;

    public StudentController(IEventInputPort eventInputPort, IEventOutPort eventOutPort)
    {
        _eventInputPort = eventInputPort;
        _eventOutPort = eventOutPort;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        await _eventInputPort.GetAllAsync();
        var response = _eventOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _eventInputPort.GetById(id);
        var response = _eventOutPort.GetResponse;

        return Ok(response);
    }

    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ResearchController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ResearchController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}