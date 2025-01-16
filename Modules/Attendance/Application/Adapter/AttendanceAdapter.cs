using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
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
            _attendanceOutPort.Success(new AttendanceDto(), "El docente " + teacher.FirstName + " " + teacher.LastName + " ha sido registrado");
            return;
        }else if (data.Role == 1)
        {
            var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.IdStudent == data.IdParticipant);
            if(student == null)
            {
                _attendanceOutPort.Success(new object(),"Debe registrar al estudiante para agregarlo");
                return;
            }

            var participanS = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent && x.EventId == data.EventId);
            if(participanS != null)
            {
                _attendanceOutPort.Success(new object(),"El estudiante ya se encuentra registrado en evento seleccionado");
                return;
            }

            attendance.StudentId = student.IdStudent;
            await _attendanceRepository.AddAsync(attendance);
            
            _attendanceOutPort.Success(new object(),"El estudiante "+student.FirstName + " " + student.LastName + " ha sido registrado");
            return;
        }
        
        var guest = await _attendanceRepository.GetAsync<GuestEntity>(x => x.IdGuest == data.IdParticipant);
        if (guest == null)
        {
            _attendanceOutPort.Success("Debe registrar al invitado para agregarlo");
            return;
        }

        var participantG = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.GuestId == guest.IdGuest && x.EventId == data.EventId);
        if (participantG != null)
        {
            _attendanceOutPort.Success("El invitado ya se encuentra registrado en el evento seleccionado");
            return;
        }

        attendance.GuestId = guest.IdGuest;
        await _attendanceRepository.AddAsync(attendance);

        _attendanceOutPort.Success(new object(),"El invitado " + guest.FirstName + " " + guest.LastName + " ha sido registrado");
    
    }
    
    public async Task TakeAttendance(InsertAttendanceDto attendanceDto)
{
    var teacher = await _attendanceRepository.GetAsync<TeacherEntity>(x => x.Dni == attendanceDto.Dni);
    var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.Dni == attendanceDto.Dni);
    var guest = await _attendanceRepository.GetAsync<GuestEntity>(x => x.Dni == attendanceDto.Dni);

    AttendanceEntity attendance = new AttendanceEntity();

    if (teacher != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.TeacherId == teacher.IdTeacher);
        if ( attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "El docente ya se encuentra registrado");
            return;
        }
    }
    else if (student != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent);
        if (attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "El estudiante ya se encuentra registrado");
            return;
        }
    }
    else if (guest != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.GuestId == guest.IdGuest);
        if (attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "El invitado ya se encuentra registrado");
            return;
        }
        if (attendance == null)
        {
            _attendanceOutPort.Error("No se encontró el participante, registrelo");
            return;
        }
    }


    attendance = new AttendanceEntity();
    attendance.Date = DateTime.Now;
    attendance.EventId = attendanceDto.EventId;
    attendance.IsPresent = true;

    if (teacher != null)
    {
        var resTeacher = teacher.Adapt<ParticipantDataDto>();
        resTeacher.Role = 0;
        attendance.TeacherId = teacher.IdTeacher;
        await _attendanceRepository.UpdateAsync(attendance);
        _attendanceOutPort.TakeAttendance(resTeacher);
    }
    else if (student != null)
    {
        var resStudent = student.Adapt<ParticipantDataDto>();
        resStudent.Role = 1;
        attendance.StudentId = student.IdStudent;
        await _attendanceRepository.UpdateAsync(attendance);
        _attendanceOutPort.TakeAttendance(resStudent);
    }
    else if (guest != null)
    {
        var resGuest = guest.Adapt<ParticipantDataDto>();
        resGuest.Role = 2;
        attendance.GuestId = guest.IdGuest;
        await _attendanceRepository.UpdateAsync(attendance);
        _attendanceOutPort.TakeAttendance(resGuest);
    }
}
}