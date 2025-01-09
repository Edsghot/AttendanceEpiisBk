namespace AttendanceEpiisBk.Model.Dtos.Event;

public record ParticipantDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Role { get; set; }
    public bool IsPresent { get; set; }
    public DateTime Date { get; set; }
}