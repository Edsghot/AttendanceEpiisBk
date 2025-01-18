using AttendanceEpiisBk.Model.Dtos.Attedance;

namespace AttendanceEpiisBk.Model.Dtos.Guest;

public record GuestAttendanceDto
{
    
    public int? IdGuest { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Dni { get; set; }
    public AttendanceDto Attendance { get; set; }
}