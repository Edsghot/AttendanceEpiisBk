using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Model.Dtos.User;

namespace AttendanceEpiisBk.Modules.User.Application.Port;

public interface IUserOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<UserDto> data);
    void GetById(UserDto user);
  
}