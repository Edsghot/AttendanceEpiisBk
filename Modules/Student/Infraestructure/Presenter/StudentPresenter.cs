using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Student;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Student.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;

namespace AttendanceEpiisBk.Modules.Student.Infraestructure.Presenter;

public class StudentPresenter : BasePresenter<object>, IStudentOutPort
{
    public void GetAllAsync(IEnumerable<StudentDto> data)
    {
        Success(data);
    }

    public void GetById(StudentDto data)
    {
        Success(data);
    }
}