namespace AttendanceEpiisBk.Model.Dtos.Attedance;

public record InsertAttendanceDto
{
    public string Dni { get; set; }
    public int EventId { get; set; }
}