namespace AttendanceEpiisBk.Model.Dtos.User;

public record UserDto
{
    public int? IdUser { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string NameUser { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public string Dni { get; set; } = string.Empty;

}