namespace AttendanceEpiisBk.Model.Dtos.Attedance;

public record AttendanceDto
{
    public int? IdAttendance { get; set; }
    public DateTime? Date { get; set; }
    public bool? IsPresent { get; set; }
    public bool? IsDeparture { get; set; }
    public int EventId { get; set; }
    public int? StudentId { get; set; }
    public int? TeacherId { get; set; }
    public  bool? IsLate { get; set; }
    public DateTime? DepartureDate { get; set; }
}