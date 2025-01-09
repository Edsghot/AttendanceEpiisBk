namespace AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

public record TeacherEntity
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
    public string? Description { get; set; } = string.Empty;
    public string? Instagram { get; set; }
    public string? LinkedIn { get; set; }
    public string Position { get; set; } = string.Empty;
    public ICollection<WorkExperienceEntity> WorkExperiences { get; set; }
    public ICollection<TeachingExperienceEntity> TeachingExperiences { get; set; }
    public ICollection<ThesisAdvisingExperienceEntity> ThesisAdvisingExperiences { get; set; }
}