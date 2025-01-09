using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Event.Application.Port;

namespace AttendanceEpiisBk.Modules.Attendance.Infraestructure.Presenter;

public class AttendancePresenter : BasePresenter<object>, IAttendanceOutPort
{
    public void GetAllAsync(IEnumerable<AttendanceDto> data)
    {
        Success(data);
    }

    public void GetById(AttendanceDto data)
    {
        Success(data);
    }
}