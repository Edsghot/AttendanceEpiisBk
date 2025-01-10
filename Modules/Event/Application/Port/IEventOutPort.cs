using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Event.Application.Port;

public interface IEventOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<EventDto> data);
    void GetById(EventDto teacher);
    void EventAdded();
    void GetParticipants(IEnumerable<ParticipantDto> data);
    void GetAllGuest(IEnumerable<GuestDto> data);
}