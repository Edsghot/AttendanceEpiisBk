using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Student;
using Mapster;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Mapping;

public class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<TeacherEntity, TeacherDto>.NewConfig();
        TypeAdapterConfig<EventEntity, EventDto>.NewConfig();
        TypeAdapterConfig<StudentEntity, StudentDto>.NewConfig();
        TypeAdapterConfig<AttendanceEntity, AttendanceDto>.NewConfig();
        TypeAdapterConfig<ParticipantDto, StudentDto>.NewConfig();
        TypeAdapterConfig<ParticipantDto, TeacherDto>.NewConfig();
    }
}