namespace AttendanceEpiisBk.Model.Dtos.Teacher;

public record TeacherDto
{
    public int IdTeacher { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string RegistrationCode { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? LinkedIn { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public List<WorkExperienceDto> WorkExperiences { get; set; } = new();
    public List<TeachingExperienceDto> TeachingExperiences { get; set; } = new();
    public List<ThesisAdvisingExperienceDto> ThesisAdvisingExperiences { get; set; } = new();
}