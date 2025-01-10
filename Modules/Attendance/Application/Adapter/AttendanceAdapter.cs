using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
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
    private readonly IAttendanceOutPort _attendanceOutPort;
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceAdapter(IAttendanceRepository repository, IAttendanceOutPort attendanceOutPort)
    {
        _attendanceRepository = repository;
        _attendanceOutPort = attendanceOutPort;
    }

    public async Task GetById(int id)
    {
        var attendances = await _attendanceRepository.GetAsync<AttendanceEntity>(
            x => x.IdAttendance == id);
        if (attendances == null)
        {
            _attendanceOutPort.NotFound("No attendance found.");
            return;
        }

        var attendanceDtos = attendances.Adapt<AttendanceDto>();
        _attendanceOutPort.GetById(attendanceDtos);
    }

    public async Task GetAllAsync()
    {
        var attendances = await _attendanceRepository.GetAllAsync<AttendanceEntity>( );

        var attendanceEntities = attendances.ToList();
        if (!attendanceEntities.Any())
        {
            _attendanceOutPort.NotFound("No attendance found.");
            return;
        }

        var attendanceDtos = attendances.Adapt<List<AttendanceDto>>();

        _attendanceOutPort.GetAllAsync(attendanceDtos);
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
            var teacher = await _attendanceRepository.GetAsync<TeacherEntity>(x => x.IdTeacher == data.IdParticipant);
            if(teacher == null)
            {
                _attendanceOutPort.Error("Debe registrar al docente para agregarlo");
                return;
            }

            var participant = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.TeacherId == teacher.IdTeacher && x.EventId == data.EventId);
            if(participant != null)
            {
                _attendanceOutPort.Error("El docente ya se encuentra registrado en el evento seleccionado");
                return;
            }

            attendance.TeacherId = teacher.IdTeacher;
            await _attendanceRepository.AddAsync(attendance);
            await _attendanceRepository.SaveChangesAsync();
            
            _attendanceOutPort.Success("El docente "+teacher.FirstName + " " + teacher.LastName + " ha sido registrado");
            return;
        }
        
        var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.IdStudent == data.IdParticipant);
        if(student == null)
        {
            _attendanceOutPort.Error("Debe registrar al estudiante para agregarlo");
            return;
        }

        var participanS = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent && x.EventId == data.EventId);
        if(participanS != null)
        {
            _attendanceOutPort.Error("El estudiante ya se encuentra registrado en evento seleccionado");
            return;
        }

        attendance.StudentId = student.IdStudent;
        await _attendanceRepository.AddAsync(attendance);
        await _attendanceRepository.SaveChangesAsync();
            
        _attendanceOutPort.Success("El estudiante "+student.FirstName + " " + student.LastName + " ha sido registrado");
    }
    
    public async Task TakeAttendance(InsertAttendanceDto attendanceDto)
    {
        var teacher = await _attendanceRepository.GetAsync<TeacherEntity>(x => x.Dni == attendanceDto.Dni);
        var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.Dni == attendanceDto.Dni);

        if (teacher == null && student == null)
        {
            _attendanceOutPort.NotFound("No se registro este participante");
            return;
        }
        var attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.TeacherId == teacher.IdTeacher );

        if (teacher != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success("El docente ya se encuentra registrado en este evento");
            return;            
        }
        if (teacher == null)
        {
            attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent );
 
            if (attendance.IsPresent)
            {
                _attendanceOutPort.Success("El estudiante ya se encuentra registrado en este evento");
                return;            
            }
            
            if (attendance == null)
            {
                _attendanceOutPort.Error("No se registro este participante para este evento");
                return;            
            }
            
            attendance.Date = DateTime.Now;
            attendance.IsPresent = true;
            await _attendanceRepository.UpdateAsync(attendance);
            await _attendanceRepository.SaveChangesAsync();
            var res = student.Adapt<ParticipantDataDto>();
            res.Role = 1;
            _attendanceOutPort.TakeAttendance(res);
        }
       
        
        attendance.Date = DateTime.Now;
        attendance.IsPresent = true;
        await _attendanceRepository.UpdateAsync(attendance);
        await _attendanceRepository.SaveChangesAsync();
        var resTeacher = teacher.Adapt<ParticipantDataDto>();
        resTeacher.Role = 0;
        _attendanceOutPort.TakeAttendance(resTeacher);
    }
}