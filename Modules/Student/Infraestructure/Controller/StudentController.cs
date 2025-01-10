﻿using AttendanceEpiisBk.Model.Dtos.Student;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Student.Application.Port;

namespace AttendanceEpiisBk.Modules.Student.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentInputPort _studentInputPort;
    private readonly IStudentOutPort _studentOutPort;

    public StudentController(IStudentInputPort studentInputPort, IStudentOutPort studentOutPort)
    {
        _studentInputPort = studentInputPort;
        _studentOutPort = studentOutPort;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        await _studentInputPort.GetAllAsync();
        var response = _studentOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _studentInputPort.GetById(id);
        var response = _studentOutPort.GetResponse;

        return Ok(response);
    }
    
    [HttpPost("CreateStudent")]
    public async Task<IActionResult> CreateStudent([FromBody] StudentDto teacherDto)
    {
        await _studentInputPort.CreateStudent(teacherDto);
        var response = _studentOutPort.GetResponse;
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