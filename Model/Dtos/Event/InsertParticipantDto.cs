namespace AttendanceEpiisBk.Model.Dtos.Event;

public record InsertParticipantDto
{
    public int EventId { get; set; }
    public int Role { get; set; }
    public int IdParticipant { get; set; }
}