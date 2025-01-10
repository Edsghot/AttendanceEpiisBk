using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

public record TeacherEntity
{
    public int IdTeacher { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public string Dni { get; set; } = string.Empty;
    public ICollection<AttendanceEntity> Attendances { get; set; }
}