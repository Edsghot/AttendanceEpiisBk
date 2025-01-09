namespace AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

public record ThesisAdvisingExperienceEntity
{
    public int Id { get; set; }
    public string University { get; set; } = string.Empty;
    public string Thesis { get; set; } = string.Empty;
    public string ThesisStudent { get; set; } = string.Empty;
    public string Repository { get; set; } = string.Empty;
    public DateTime ThesisAcceptanceDate { get; set; }
    public int TeacherId { get; set; }
    public TeacherEntity Teacher { get; set; }
}