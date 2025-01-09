
namespace AttendanceEpiisBk.Modules.Teacher.Application.Port;

public interface ITeacherInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task ParticipantGetByDni(string dni);
}