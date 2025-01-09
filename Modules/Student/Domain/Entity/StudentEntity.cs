using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Student.Domain.Entity;

public record StudentEntity
{
    public int IdStudent { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Dni { get; set; } = string.Empty;

    public ICollection<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();
}