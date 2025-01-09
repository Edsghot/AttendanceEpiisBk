using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Teacher.Application.Port;

public interface ITeacherOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<TeacherDto> data);
    void GetById(TeacherDto teacher);
}