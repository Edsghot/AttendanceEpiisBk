
using AttendanceEpiisBk.Model.Dtos.Event;

namespace AttendanceEpiisBk.Modules.Event.Application.Port;

public interface IEventInputPort
{
    Task GetById(int id);
    Task GetAllAsync();
    Task AddEventAsync(EventDto eventDto);
    Task GetParticipantsAsync(int eventId);
}