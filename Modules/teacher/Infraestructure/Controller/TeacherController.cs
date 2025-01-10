﻿using AttendanceEpiisBk.Model.Dtos.Teacher;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;

namespace AttendanceEpiisBk.Modules.Teacher.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherInputPort _teacherInputPort;
    private readonly ITeacherOutPort _teacherOutPort;

    public TeacherController(ITeacherInputPort teacherInputPort, ITeacherOutPort teacherOutPort)
    {
        _teacherInputPort = teacherInputPort;
        _teacherOutPort = teacherOutPort;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        await _teacherInputPort.GetAllAsync();
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _teacherInputPort.GetById(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }
    
    [HttpGet("ParticipantGetByDni/{dni}")]
    public async Task<IActionResult> ParticipantGetByDni([FromRoute] string dni)
    {
        await _teacherInputPort.ParticipantGetByDni(dni);
        var response = _teacherOutPort.GetResponse;
        return Ok(response);
    }

    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost("CreateTeacher")]
    public async Task<IActionResult> CreateTeacher([FromBody] TeacherDto teacherDto)
    {
        await _teacherInputPort.CreateTeacher(teacherDto);
        var response = _teacherOutPort.GetResponse;
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