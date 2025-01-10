using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Event.Application.Port;

namespace AttendanceEpiisBk.Modules.Event.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventInputPort _eventInputPort;
    private readonly IEventOutPort _eventOutPort;

    public EventController(IEventInputPort eventInputPort, IEventOutPort eventOutPort)
    {
        _eventInputPort = eventInputPort;
        _eventOutPort = eventOutPort;
    }

    [HttpGet("GetAll")]
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventDto eventDto)
    {
        await _eventInputPort.AddEventAsync(eventDto);
        var response = _eventOutPort.GetResponse;

        return Ok(response);
    }
    
    [HttpGet("GetParticipants/{eventId:int}")]
    public async Task<IActionResult> GetParticipants([FromRoute] int eventId)
    {
        await _eventInputPort.GetParticipantsAsync(eventId);
        return Ok(_eventOutPort.GetResponse);
    }
    
    [HttpPost("CreateGuest")]
    public async Task<IActionResult> CreateGuest([FromBody] GuestDto data)
    {
        await _eventInputPort.CreateGuest(data);
        var response = _eventOutPort.GetResponse;
        return Ok(response);
    }    
    
    [HttpGet("GetAllGuest")]
    public async Task<IActionResult> GetAllGuest()
    {
        await _eventInputPort.GetAllGuest();
        var response = _eventOutPort.GetResponse;

        return Ok(response);
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