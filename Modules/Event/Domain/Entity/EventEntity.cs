using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Event.Domain.Entity;

public record EventEntity
{
    public int IdEvent { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public bool IsPrivate { get; set; }
    public string Description { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public int EventTypeId { get; set; }

    public ICollection<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();
}