
namespace AttendanceEpiisBk.Modules.Event.Application.Port;

public interface IEventInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
}