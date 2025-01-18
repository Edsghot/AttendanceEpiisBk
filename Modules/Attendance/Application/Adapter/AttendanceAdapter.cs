using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Participant;
using AttendanceEpiisBk.Model.Dtos.Student;
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
        var peruTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
        var peruDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, peruTimeZone);
        var attendance = new AttendanceEntity
        {
            IsPresent = false,
            Date = peruDateTime,
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
    
    TimeZoneInfo peruTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
    DateTime peruDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, peruTimeZone);
    var teacher = await _attendanceRepository.GetAsync<TeacherEntity>(x => x.Dni == attendanceDto.Dni);
    var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.Dni == attendanceDto.Dni);
    var guest = await _attendanceRepository.GetAsync<GuestEntity>(x => x.Dni == attendanceDto.Dni);

    AttendanceEntity attendance = new AttendanceEntity();

    if (teacher != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.TeacherId == teacher.IdTeacher);
        if ( attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "La asistencia ya fue tomada!");
            return;
        }
    }
    else if (student != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.StudentId == student.IdStudent);
        if (attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "La asistencia ya fue tomada!");
            return;
        }
    }
    else if (guest != null)
    {
        attendance = await _attendanceRepository.GetAsync<AttendanceEntity>(x => x.GuestId == guest.IdGuest);
        if (attendance != null && attendance.IsPresent)
        {
            _attendanceOutPort.Success(new object(), "La asistencia ya fue tomada!");
            return;
        }
        if (attendance == null)
        {
            _attendanceOutPort.Error("No se encontró el participante, registrelo");
            return;
        }
        var resGuest = guest.Adapt<ParticipantDataDto>();
        resGuest.Role = 2;
        attendance.Date = peruDateTime;
        attendance.EventId = attendanceDto.EventId;
        attendance.IsLate = attendanceDto.IsLate;
        attendance.DepartureDate = attendanceDto.DepartureDate;
        attendance.IsPresent = true;
        attendance.GuestId = guest.IdGuest;
        await _attendanceRepository.UpdateAsync(attendance);
        _attendanceOutPort.TakeAttendance(resGuest);

        return;
    }


    attendance = new AttendanceEntity();
    
    attendance.IsLate = attendanceDto.IsLate;
    attendance.DepartureDate = attendanceDto.DepartureDate;
    attendance.Date = peruDateTime;
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
    else
    {
        var resStudent = student.Adapt<ParticipantDataDto>();
        resStudent.Role = 1;
        attendance.StudentId = student.IdStudent;
        await _attendanceRepository.UpdateAsync(attendance);
        _attendanceOutPort.TakeAttendance(resStudent);
    }
}

public async Task ReportByEventId(int id)
{
    var resEvent = await _attendanceRepository.GetAsync<EventEntity>(x => x.IdEvent == id);

    if (resEvent is null)
    {
        _attendanceOutPort.Error("No se encontró el evento");
        return;
    }

    var attendances = await _attendanceRepository.GetAllAsync<AttendanceEntity>(x => x.Where(e => e.EventId == resEvent.IdEvent));
    var attendanceList = attendances.ToList();

    var report = new ReportAttendanceEventDto
    {
        Event = resEvent.Adapt<EventAttendanceDto>(),
        ListStudentAttendance = new List<StudentAttendanceDto>(),
        ListTeacherAttendance = new List<TeacherAttendanceDto>(),
        ListGuestAttendancee = new List<GuestAttendanceDto>()
    };

    foreach (var attendance in attendanceList)
    {
        if (attendance.StudentId.HasValue)
        {
            var student = await _attendanceRepository.GetAsync<StudentEntity>(x => x.IdStudent == attendance.StudentId.Value);
            if (student != null)
            {
                var studentAttendance = student.Adapt<StudentAttendanceDto>();
                studentAttendance.Attendance = attendance.Adapt<AttendanceDto>();
                report.ListStudentAttendance.Add(studentAttendance);
            }
        }
        else if (attendance.TeacherId.HasValue)
        {
            var teacher = await _attendanceRepository.GetAsync<TeacherEntity>(x => x.IdTeacher == attendance.TeacherId.Value);
            if (teacher != null)
            {
                var teacherAttendance = teacher.Adapt<TeacherAttendanceDto>();
                teacherAttendance.Attendance = attendance.Adapt<AttendanceDto>();
                report.ListTeacherAttendance.Add(teacherAttendance);
            }
        }
        else if (attendance.GuestId.HasValue)
        {
            var guest = await _attendanceRepository.GetAsync<GuestEntity>(x => x.IdGuest == attendance.GuestId.Value);
            if (guest != null)
            {
                var guestAttendance = guest.Adapt<GuestAttendanceDto>();
                guestAttendance.Attendance = attendance.Adapt<AttendanceDto>();
                report.ListGuestAttendancee.Add(guestAttendance);
            }
        }
    }

    _attendanceOutPort.Success(report, "Reporte generado exitosamente.");
}
}