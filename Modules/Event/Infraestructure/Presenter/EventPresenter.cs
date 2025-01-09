using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Event;
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
}