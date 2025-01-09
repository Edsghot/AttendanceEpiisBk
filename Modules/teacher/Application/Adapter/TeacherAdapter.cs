using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Teacher.Application.Adapter;

public class TeacherAdapter : ITeacherInputPort
{
    private readonly ITeacherOutPort _teacherOutPort;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherAdapter(ITeacherRepository repository, ITeacherOutPort teacherOutPort)
    {
        _teacherRepository = repository;
        _teacherOutPort = teacherOutPort;
    }

    public async Task GetById(int id)
    {
        var teachers = await _teacherRepository.GetAsync<TeacherEntity>(
            x => x.IdTeacher == id);
        if (teachers == null)
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<TeacherDto>();
        _teacherOutPort.GetById(teacherDtos);
    }

    public async Task GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync<TeacherEntity>( );

        var teacherEntities = teachers.ToList();
        if (!teacherEntities.Any())
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<List<TeacherDto>>();

        _teacherOutPort.GetAllAsync(teacherDtos);
    }
}