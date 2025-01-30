using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Event.Application.Port;
using AttendanceEpiisBk.Modules.User.Application.Port;

namespace AttendanceEpiisBk.Modules.User.Infraestructure.Presenter;

public class UserPresenter : BasePresenter<object>, IUserOutPort
{
    public void GetAllAsync(IEnumerable<UserDto> data)
    {
        Success(data);
    }

    public void GetById(UserDto data)
    {
        Success(data);
    }

    public void TakeAttendance(ParticipantDataDto data)
    {
        Success(data);
    }
}