namespace AttendanceEpiisBk.Model.Dtos.User;

public record LoginDto
{
    public string Username { get; init; } 
    public string Password { get; init; }
}