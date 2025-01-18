namespace AttendanceEpiisBk.Model.Dtos.Event;

public record EventAttendanceDto
{
    public int? IdEvent { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsPrivate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int EventTypeId { get; set; }
    public bool AllTeacher { get; set; }
    public bool AllStudent { get; set; }
    public bool AllGuest { get; set; }
}