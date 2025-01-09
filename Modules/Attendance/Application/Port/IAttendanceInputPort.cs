
namespace AttendanceEpiisBk.Modules.Attendance.Application.Port;

public interface IAttendanceInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
}