namespace AttendanceEpiisBk.Model.Dtos.Participant;

public record ParticipantDataDto
{
    public int IdTeacher { get; set; }
    public int IdStudent { get; set; }
    public int IdGuest { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Dni { get; set; } = string.Empty;
    public int Role { get; set; }

}