using AttendanceEpiisBk.Model.Dtos.Attedance;

namespace AttendanceEpiisBk.Model.Dtos.Guest;

public record GuestAttendanceDto : GuestDto
{
    public AttendanceDto Attendance { get; set; }
}