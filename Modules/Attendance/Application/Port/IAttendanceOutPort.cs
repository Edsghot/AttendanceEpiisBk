using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Attendance.Application.Port;

public interface IAttendanceOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<AttendanceDto> data);
    void GetById(AttendanceDto teacher);
    void TakeAttendance(ParticipantDataDto data);
}