using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Attendance.Application.Adapter;

public class AttendanceAdapter : IAttendanceInputPort
{
    private readonly IAttendanceOutPort _eventOutPort;
    private readonly IAttendanceRepository _eventRepository;

    public AttendanceAdapter(IAttendanceRepository repository, IAttendanceOutPort eventOutPort)
    {
        _eventRepository = repository;
        _eventOutPort = eventOutPort;
    }

    public async Task GetById(int id)
    {
        var events = await _eventRepository.GetAsync<AttendanceEntity>(
            x => x.IdAttendance == id);
        if (events == null)
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<AttendanceDto>();
        _eventOutPort.GetById(eventDtos);
    }

    public async Task GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync<AttendanceEntity>( );

        var eventEntities = events.ToList();
        if (!eventEntities.Any())
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<List<AttendanceDto>>();

        _eventOutPort.GetAllAsync(eventDtos);
    }

    public async Task AddParticipant(InsertParticipantDto data)
    {
        var attendance = new AttendanceEntity
        {
            IsPresent = false,
            Date = DateTime.Now,
            EventId = data.EventId
        };
        
        //docente
        if(data.Role  == 0)
        {
            var teacher = await _eventRepository.GetAsync<TeacherEntity>(x => x.IdTeacher == data.IdParticipant);
            if(teacher == null)
            {
                _eventOutPort.Error("Debe registrar al docente para agregarlo");
                return;
            }

            var participant = await _eventRepository.GetAsync<AttendanceEntity>(x => x.TeacherId == teacher.IdTeacher);
            if(participant != null)
            {
                _eventOutPort.Error("El docente ya se encuentra registrado");
                return;
            }

            attendance.TeacherId = teacher.IdTeacher;
            await _eventRepository.AddAsync(attendance);
            await _eventRepository.SaveChangesAsync();
            
            _eventOutPort.Success("El docente "+teacher.FirstName + " " + teacher.LastName + " ha sido registrado");
            return;
        }
        
        var student = await _eventRepository.GetAsync<StudentEntity>(x => x.IdStudent == data.IdParticipant);
        if(student == null)
        {
            _eventOutPort.Error("Debe registrar al estudiante para agregarlo");
            return;
        }

        var participanS = await _eventRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent);
        if(participanS != null)
        {
            _eventOutPort.Error("El estudiante ya se encuentra registrado");
            return;
        }

        attendance.StudentId = student.IdStudent;
        await _eventRepository.AddAsync(attendance);
        await _eventRepository.SaveChangesAsync();
            
        _eventOutPort.Success("El estudiante "+student.FirstName + " " + student.LastName + " ha sido registrado");
    }
}