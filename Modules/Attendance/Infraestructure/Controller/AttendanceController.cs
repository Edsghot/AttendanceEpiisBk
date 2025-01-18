using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;

namespace AttendanceEpiisBk.Modules.Attendance.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceInputPort _attendanceInputPort;
    private readonly IAttendanceOutPort _attendanceOutPort;

    public AttendanceController(IAttendanceInputPort attendanceInputPort, IAttendanceOutPort attendanceOutPort)
    {
        _attendanceInputPort = attendanceInputPort;
        _attendanceOutPort = attendanceOutPort;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        await _attendanceInputPort.GetAllAsync();
        var response = _attendanceOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _attendanceInputPort.GetById(id);
        var response = _attendanceOutPort.GetResponse;

        return Ok(response);
    }

    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>/AddParticipant
    [HttpPost("AddParticipant")]
    public async Task<IActionResult> AddParticipant([FromBody] InsertParticipantDto participantDto)
    {
       
            await _attendanceInputPort.AddParticipant(participantDto);
            return Ok(_attendanceOutPort.GetResponse); 
    }
    
    
    [HttpPost("TakeAttendance")]
    public async Task<IActionResult> TakeAttendance([FromBody] InsertAttendanceDto participantDto)
    {
       
        await _attendanceInputPort.TakeAttendance(participantDto);
        return Ok(_attendanceOutPort.GetResponse); 
    }

    [HttpGet("ReportAttendanceByEvent/{id:int}")]
    public async Task<IActionResult> ReportAttendanceByEvent([FromRoute] int id)
    {
        await _attendanceInputPort.ReportByEventId(id);
        return Ok(_attendanceOutPort.GetResponse); 
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