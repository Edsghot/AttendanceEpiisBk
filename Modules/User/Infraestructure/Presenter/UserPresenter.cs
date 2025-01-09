using AttendanceEpiisBk.Model.Dtos.Response;
using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.User.Application.Port;

namespace AttendanceEpiisBk.Modules.User.Infraestructure.Presenter;

public class UserPresenter : BasePresenter<object>, IUserOutPort
{
    public void GetAllUsersAsync(IEnumerable<UserDto> data)
    {
        Success(data, "Users successfully retrieved.");
    }

    public void NotFound(string message = "Data not found")
    {
        base.NotFound(message);
    }
}