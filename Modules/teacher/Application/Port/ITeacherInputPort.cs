using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.User.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Teacher.Application.Port;

public interface ITeacherInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
}