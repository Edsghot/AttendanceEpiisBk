using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Model.Dtos.Teacher;

public record TeacherAttendanceDto : TeacherDto
{
    public AttendanceDto Attendance { get; set; }
}