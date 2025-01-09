namespace AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

public record TeachingExperienceEntity
{
    public int Id { get; set; }
    public string Institution { get; set; } = string.Empty;
    public string InstitutionType { get; set; } = string.Empty;
    public string TeacherType { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TeacherId { get; set; }
    public TeacherEntity Teacher { get; set; }
}