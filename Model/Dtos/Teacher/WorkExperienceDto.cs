namespace AttendanceEpiisBk.Model.Dtos.Teacher;

public record WorkExperienceDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string JobIdi { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? JobDescription { get; set; } = string.Empty;
    public bool IsCurrent { get; set; }
    public int TeacherId { get; set; }
}