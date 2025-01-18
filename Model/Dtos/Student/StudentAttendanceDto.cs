using AttendanceEpiisBk.Model.Dtos.Attedance;

namespace AttendanceEpiisBk.Model.Dtos.Student;

public record StudentAttendanceDto 
{
    public int? IdStudent { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public string Dni { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public AttendanceDto  Attendance { get; set; }
}