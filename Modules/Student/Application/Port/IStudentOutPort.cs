using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Student;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Student.Application.Port;

public interface IStudentOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<StudentDto> data);
    void GetById(StudentDto teacher);
}