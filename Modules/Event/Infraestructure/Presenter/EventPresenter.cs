using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Event.Application.Port;

namespace AttendanceEpiisBk.Modules.Event.Infraestructure.Presenter;

public class EventPresenter : BasePresenter<object>, IEventOutPort
{
    public void GetAllAsync(IEnumerable<EventDto> data)
    {
        Success(data);
    }

    public void GetById(EventDto data)
    {
        Success(data);
    }

    public void EventAdded()
    {
        Success("Evento creado correctamente");
    }

    public void GetParticipants(IEnumerable<ParticipantDto> data)
    {
        Success(data);
    }

    public void GetAllGuest(IEnumerable<GuestDto> data)
    {
        Success(data);
    }
}