
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.User;

namespace AttendanceEpiisBk.Modules.user.Application.Port;

public interface IUserInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task Add(UserDto data);
    Task Update(UserDto data);
    Task Delete(int id);
    Task Login(string username, string password);
}