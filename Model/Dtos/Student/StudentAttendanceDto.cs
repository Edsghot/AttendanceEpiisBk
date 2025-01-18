using AttendanceEpiisBk.Model.Dtos.Attedance;

namespace AttendanceEpiisBk.Model.Dtos.Student;

public record StudentAttendanceDto : StudentDto
{
    public AttendanceDto  Attendance { get; set; }
}