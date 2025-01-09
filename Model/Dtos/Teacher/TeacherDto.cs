using AttendanceEpiisBk.Model.Dtos.Attedance;

namespace AttendanceEpiisBk.Model.Dtos.Teacher;

public record TeacherDto
{
    public int IdTeacher { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Dni { get; set; } = string.Empty;
    public List<AttendanceDto> Attendances { get; set; } = default!;
}