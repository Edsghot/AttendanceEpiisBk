using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Event.Domain.Entity;

public record EventEntity
{
    public int IdEvent { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public bool IsPrivate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int EventTypeId { get; set; }
    public bool TodoTeacher { get; set; }

    public ICollection<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();
}