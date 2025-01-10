using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Event.Domain.Entity;

public record GuestEntity
{
    public int IdGuest { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }
    public string Mail { get; set; }
    
    public ICollection<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();    
}