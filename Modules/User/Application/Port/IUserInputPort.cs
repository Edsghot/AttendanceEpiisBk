using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.User.Domain.Entity;

namespace AttendanceEpiisBk.Modules.User.Application.Port;

public interface IUserInputPort
{
    Task GetAllUsersAsync();
}