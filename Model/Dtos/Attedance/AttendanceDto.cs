namespace AttendanceEpiisBk.Model.Dtos.Attedance;

public record AttendanceDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int EventId { get; set; }
    public int StudentId { get; set; }
    
    public int TeacherId { get; set; }
}