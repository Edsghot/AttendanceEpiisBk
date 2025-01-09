using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.User;

namespace AttendanceEpiisBk.Modules.User.Application.Port;

public interface IUserOutPort : IBasePresenter<object>
{
    void GetAllUsersAsync(IEnumerable<UserDto> data);
}