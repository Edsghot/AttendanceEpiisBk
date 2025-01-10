using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
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

    public async Task ParticipantGetByDni(string dni)
    {
        var teachers = await _teacherRepository.GetAsync<TeacherEntity>(x => x.Dni.Equals(dni));
        
        if(teachers == null)
        {
            var students = await _teacherRepository.GetAsync<StudentEntity>(e => e.Dni.Equals(dni));

            var response = students.Adapt<ParticipantDataDto>();
            response.Role = 1;
            _teacherOutPort.ParticipantGetByDni(response);
            return;
            
        }
        
        var res = teachers.Adapt<ParticipantDataDto>();
        res.Role = 0;
        _teacherOutPort.ParticipantGetByDni(res);
    }
    
    public async Task CreateTeacher(TeacherDto teacherDto)
    {
        var teacherEntity = teacherDto.Adapt<TeacherEntity>();
        await _teacherRepository.AddAsync(teacherEntity);
        await _teacherRepository.SaveChangesAsync();
        _teacherOutPort.Success(teacherEntity, "Teacher created successfully.");
    }
}
        
