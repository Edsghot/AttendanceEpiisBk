using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Model.Dtos.Teacher;

public record TeacherAttendanceDto  {
    
    public int? IdTeacher { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public string Dni { get; set; } = string.Empty;
    
    public DateTime BirthDate { get; set; }
    public AttendanceDto Attendance { get; set; }
}